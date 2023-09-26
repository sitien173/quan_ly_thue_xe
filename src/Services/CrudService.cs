using AutoMapper;
using CarRentalManagement.Data;
using Z.EntityFramework.Plus;

namespace CarRentalManagement.Services;

public interface ICrudService<TEntity, TKey> : IReadOnlyService<TEntity, TKey>
{
    Task<TKey> AddAsync(object addViewModel);
    Task DeleteAsync(TKey id);
    Task<int> DeleteAsync(IEnumerable<TKey> ids);
    Task UpdateAsync(object editViewModel, TKey id);
}

public class CrudService<TEntity, TKey> : ReadOnlyService<TEntity, TKey>, ICrudService<TEntity, TKey> where TEntity : class
{
    protected CrudService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    protected virtual Task ValidateBeforeAddAsync(object addViewModel)
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task AdditionToEntityBeforeAddAsync(TEntity persistence, object addViewModel)
    {
        return Task.CompletedTask;
    }
    
    public virtual async Task<TKey> AddAsync(object addViewModel)
    {
        await ValidateBeforeAddAsync(addViewModel).ConfigureAwait(false);
        
        var persistence = Mapper.Map<TEntity>(addViewModel);
        
        await AdditionToEntityBeforeAddAsync(persistence, addViewModel).ConfigureAwait(false);
        
        var add = await DbSet.AddAsync(persistence).ConfigureAwait(false);
        
        await Context.SaveChangesAsync().ConfigureAwait(false);
        
        return add.OriginalValues.GetValue<TKey>("Id");
    }
    
    public virtual Task DeleteAsync(TKey id)
    {
        return DbSet
            .WhereDynamic(x => "x.Id == id && !x.IsDeleted", new { id })
            .UpdateAsync(new Dictionary<string, object>()
            {
                { "IsDeleted", true }
            });
    }

    public virtual Task<int> DeleteAsync(IEnumerable<TKey> ids)
    {
        return DbSet
            .WhereDynamic(x => "ids.Contains(x.Id) && !x.IsDeleted", new { ids })
            .UpdateAsync(new Dictionary<string, object>()
            {
                { "IsDeleted", true }
            });
    }

    protected virtual Task ValidateBeforeUpdateAsync(TEntity entity, object editViewModel)
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task AdditionToEntityBeforeUpdateAsync(TEntity entity, object editViewModel)
    {
        return Task.CompletedTask;
    }
    
    public virtual async Task UpdateAsync(object editViewModel, TKey id)
    {
        var entity = await FindOrElseThrowAsync(id).ConfigureAwait(false);
        
        await ValidateBeforeUpdateAsync(entity, editViewModel).ConfigureAwait(false);
        
        Mapper.Map(editViewModel, entity);
        
        await AdditionToEntityBeforeUpdateAsync(entity, editViewModel).ConfigureAwait(false);
        
        DbSet.Update(entity);
        
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }
}
