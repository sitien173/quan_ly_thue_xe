using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IBrandService : ICrudService<Brand, int>
{
}

public class BrandService : CrudService<Brand, int>, IBrandService
{
    public BrandService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
        
    }
}