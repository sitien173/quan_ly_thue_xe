using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface ISurChargeService : ICrudService<SurCharge, int>
{
}

public class SurChargeService : CrudService<SurCharge, int>, ISurChargeService
{
    public SurChargeService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}