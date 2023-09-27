using Ardalis.GuardClauses;
using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.InvoiceManagement;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface IInvoiceService : ICrudService<Invoice, int>
{
}

public class InvoiceService : CrudService<Invoice, int>, IInvoiceService
{
    public InvoiceService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}