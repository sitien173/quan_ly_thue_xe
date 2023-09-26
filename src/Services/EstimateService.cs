using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IEstimateService : ICrudService<Estimate, int>
{
}

public class EstimateService : CrudService<Estimate, int>, IEstimateService
{
    public EstimateService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}