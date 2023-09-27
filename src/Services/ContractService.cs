using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IContractService : ICrudService<Contract, int>
{
}

public class ContractService : CrudService<Contract, int>, IContractService
{
    public ContractService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}