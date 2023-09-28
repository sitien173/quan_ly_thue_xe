using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IFeatureService : ICrudService<Feature, int>
{
}

public class FeatureService : CrudService<Feature, int>, IFeatureService
{
    public FeatureService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}