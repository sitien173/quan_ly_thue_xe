using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface ICarTransferAgreementService : ICrudService<CarTransferAgreement, int>
{
}

public class CarTransferAgreementService : CrudService<CarTransferAgreement, int>, ICarTransferAgreementService
{
    public CarTransferAgreementService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}