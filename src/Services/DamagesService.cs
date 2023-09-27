using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace CarRentalManagement.Services;

public interface IDamagesService : ICrudService<Damages, int>
{
    
}

public class DamagesService : CrudService<Damages, int>, IDamagesService
{
    public DamagesService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override async Task AdditionToEntityBeforeAddAsync(Damages persistence, object addViewModel)
    {
        persistence.CarId = await Context
            .Contract
            .Where(x => x.Id == persistence.ContractId)
            .SelectMany(x => x.ContractDetails)
            .Select(x => x.CarId)
            .FirstOrDefaultAsync();
        
        await base.AdditionToEntityBeforeAddAsync(persistence, addViewModel);
    }
}