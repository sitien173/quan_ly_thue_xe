using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace CarRentalManagement.Services;

public interface ICarTransferAgreementService : ICrudService<CarTransferAgreement, int>
{
}

public class CarTransferAgreementService : CrudService<CarTransferAgreement, int>, ICarTransferAgreementService
{
    public CarTransferAgreementService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override async Task AdditionToEntityBeforeAddAsync(CarTransferAgreement persistence, object addViewModel)
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