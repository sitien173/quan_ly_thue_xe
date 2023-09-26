using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IAccidentService : ICrudService<Accident, int>
{
    
}

public class AccidentService : CrudService<Accident, int>, IAccidentService
{
    public AccidentService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}