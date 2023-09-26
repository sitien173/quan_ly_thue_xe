using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Services;

public interface IContactService : ICrudService<Contact, int>
{
}

public class ContactService : CrudService<Contact, int>, IContactService
{
    public ContactService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}