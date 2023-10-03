using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IIncidentReportsService : ICrudService<IncidentReports, int>
{
    
}

public class IncidentReportsService : CrudService<IncidentReports, int>, IIncidentReportsService
{
    public IncidentReportsService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}