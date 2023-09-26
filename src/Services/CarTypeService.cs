using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface ICarTypeService : ICrudService<CarType, int>
{
}

public class CarTypeService : CrudService<CarType, int>, ICarTypeService
{
    public CarTypeService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}