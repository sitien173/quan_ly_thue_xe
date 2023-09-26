using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IDamagesService : ICrudService<Damages, int>
{
    
}

public class DamagesService : CrudService<Damages, int>, IDamagesService
{
    public DamagesService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}