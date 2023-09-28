using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.ContractManagement;
using CarRentalManagement.Models.ViewModel.RentRequestManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Roles = Role.Accountant)]
public class ContractManagementController : AreaControllerBase
{
    private readonly IContractService _contractService;
    private readonly IRentRequestService _rentRequestService;

    public ContractManagementController(IContractService contractService, IRentRequestService rentRequestService)
    {
        _contractService = contractService;
        _rentRequestService = rentRequestService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _contractService.ListAsync<ListContractViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public async Task<IActionResult> Add()
    {
        var model = new AddContractViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CreatedBy = UserId
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddContractDetail([FromForm] AddContractViewModel model)
    {
        var rentRequest = await _rentRequestService.GetAsync<ListRentRequestViewModel>(model.RentRequestId).ConfigureAwait(false);
        model.ContractDetails = new List<AddContractViewModel.ContractDetailViewModel>()
        {
            new ()
            {
                CarId = rentRequest.CarId,
                Amount = 1,
                Price = rentRequest.TotalPrice,
                UnitPrice = rentRequest.TotalPrice,
                RentalDate = rentRequest.RentalDate,
                ReturnedDate = rentRequest.ReturnedDate,
                RentalMethod = rentRequest.RentalMethod
            }
        };
        model.Prepay = decimal.Divide(rentRequest.TotalPrice, 2);
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Preview(int id)
    {
        var response = await _contractService.GetAsync<PreviewContractViewModel>(id).ConfigureAwait(false);
        return View(response);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> SubmitContract([FromForm] AddContractViewModel model)
    {
        var contractId = await _contractService.AddAsync(model).ConfigureAwait(false);
        return RedirectToAction("Preview", new {id = contractId});
    }
    
    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _contractService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _contractService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> TerminationMinutes([FromForm] int id)
    {
        var update = new Dictionary<string, object>()
        {
            { nameof(Contract.Status), ContractStatusEnum.Finished }
        };
        
        await _contractService.UpdateAsync(update, id).ConfigureAwait(false);
        
        var model = await _contractService.GetAsync<PreviewContractViewModel>(id).ConfigureAwait(false);
        
        return View(model);
    }

    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Cancellation([FromForm] int id)
    {
        var update = new Dictionary<string, object>()
        {
            { nameof(Contract.Status), ContractStatusEnum.Canceled }
        };
        
        await _contractService.UpdateAsync(update, id).ConfigureAwait(false);
        
        var model = await _contractService.GetAsync<PreviewContractViewModel>(id).ConfigureAwait(false);
        
        return View(model);
    }
}