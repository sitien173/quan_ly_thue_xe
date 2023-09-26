using Ardalis.GuardClauses;
using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.InvoiceManagement;

namespace CarRentalManagement.Services;

public interface IInvoiceService : ICrudService<Invoice, int>
{
    Task<AddInvoiceViewModel> PrepareAddAsync(int contractId);
}

public class InvoiceService : CrudService<Invoice, int>, IInvoiceService
{
    public InvoiceService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<AddInvoiceViewModel> PrepareAddAsync(int contractId)
    {
        var contract = await Context.Contract.FindAsync(contractId).ConfigureAwait(false);
        Guard.Against.Null(contract);
        
        var model = new AddInvoiceViewModel();
        await Context.Entry(contract).Reference(x => x.Customer).LoadAsync().ConfigureAwait(false);
        await Context.Entry(contract).Collection(x => x.ContractDetails).LoadAsync().ConfigureAwait(false);
        
        model.CustomerDetail = Mapper.Map<AddInvoiceViewModel.CustomerDetailViewModel>(contract.Customer);
        model.InvoiceDetails = Mapper.Map<List<AddInvoiceViewModel.InvoiceDetailViewModel>>(contract.ContractDetails);
        
        model.Prepay = contract.Prepay;
        model.Total = contract.Total;
        model.Debt = contract.Debt;
        model.ContractId = contract.Id;
        return model;
    }
}