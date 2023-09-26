using System.Linq.Expressions;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarRentalManagement.Data;
using CarRentalManagement.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface IReadOnlyService<TEntity, TKey> : IGenericService<TEntity, TKey>
{
    Task<List<TListViewModel>> ListAsync<TListViewModel>(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEditViewModel> GetAsync<TEditViewModel>(TKey id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
}

public class ReadOnlyService<TEntity, TKey> : IReadOnlyService<TEntity, TKey> where TEntity : class
{
    protected readonly CarRentalDbContext Context;
    protected readonly IMapper Mapper;
    protected readonly DbSet<TEntity> DbSet;
    
    private const string _notFound = "Không tìm thấy";
    
    protected ReadOnlyService(CarRentalDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        DbSet = Context.Set<TEntity>();
    }

    public virtual Task<List<TDest>> ListAsync<TDest>(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return DbSet
            .AsNoTracking()
            .WhereDynamic(x => "!x.IsDeleted")
            .AddWhereClause(predicate!, predicate is not null)
            .ProjectTo<TDest>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }
    
    public virtual async Task<TDest> GetAsync<TDest>(TKey id)
    {
        var viewModel = await DbSet
            .WhereDynamic(x => "x.Id == id && !x.IsDeleted", new { id })
            .AsNoTracking()
            .ProjectTo<TDest>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync().ConfigureAwait(false);
        
        Guard.Against.Null(viewModel, message: _notFound);
        return viewModel;
    }

    protected async Task<TEntity> FindOrElseThrowAsync(TKey id)
    {
        var entity = await DbSet.FindAsync(id).ConfigureAwait(false);
        
        Guard.Against.Null(entity,  message: _notFound);
        return entity;
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        var queryable = includes.Aggregate(DbSet.AsQueryable(), (current, include) => current.Include(include));
        return queryable.FirstOrDefaultAsync(predicate);
    }
}