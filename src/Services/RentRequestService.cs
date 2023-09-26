using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IRentRequestService : ICrudService<RentRequest, int>
{
}

public class RentRequestService : CrudService<RentRequest, int>, IRentRequestService
{
    public RentRequestService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}