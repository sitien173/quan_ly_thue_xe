using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IReceiptService : ICrudService<Receipt, int>
{
    
}
public class ReceiptService : CrudService<Receipt, int>, IReceiptService
{
    public ReceiptService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}