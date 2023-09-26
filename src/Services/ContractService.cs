using Ardalis.GuardClauses;
using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.ContractManagement;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface IContractService : ICrudService<Contract, int>
{
}

public class ContractService : CrudService<Contract, int>, IContractService
{
    public ContractService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override async Task ValidateBeforeAddAsync(object model)
    {
        var addViewModel = model as AddContractViewModel;
        Guard.Against.Null(addViewModel, nameof(addViewModel));
        
        var rentRequests = await Context.RentRequest.Where(x => x.CustomerId == addViewModel.CustomerId).ToListAsync().ConfigureAwait(false);
        
        var customerNoRentals = rentRequests.Count == 0;
        Guard.Against.InvalidInput(!customerNoRentals, string.Empty, x => x, "Khách hàng chưa thêm vào sổ thuê xe");
        
        var carNotFounds = addViewModel.ContractDetails.Where(x => !rentRequests.Exists(xx => xx.CarId == x.CarId)).Select(x => x.CarId).ToArray();
        var isCarNotFounds = carNotFounds.Length > 0;
        Guard.Against.InvalidInput(!isCarNotFounds, string.Empty, x => x, $"Xe {string.Join(',', carNotFounds)} chưa được thêm vào sổ thuê xe");

        var carRentTimeNotExacts = addViewModel.ContractDetails.Where(x => !rentRequests.Exists(xx => xx.RentalDate == x.RentalDate && xx.ReturnedDate == x.ReturnedDate)).Select(x => x.CarId).ToArray();
        var isCarRentTimeNotExacts = carNotFounds.Length > 0;
        Guard.Against.InvalidInput(!isCarRentTimeNotExacts, string.Empty, x => x, $"Xe {string.Join(',', carRentTimeNotExacts)} không đúng thời gian thuê");
    }
}