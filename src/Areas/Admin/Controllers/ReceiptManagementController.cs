using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.ContractManagement;
using CarRentalManagement.Models.ViewModel.ReceiptManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;
[Authorize(Roles = Role.Accountant)]
public class ReceiptManagementController : AreaControllerBase
{
    private readonly IReceiptService _receiptService;
    private readonly IContractService _contractService;
    public ReceiptManagementController(IReceiptService receiptService, IContractService contractService)
    {
        _receiptService = receiptService;
        _contractService = contractService;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _receiptService.ListAsync<ListReceiptViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult PrepareAdd()
    {
        var model = new AddReceiptViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CreatedBy = UserId,
            CreatedAt = DateTime.Today
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> PrepareAdd([FromForm] AddReceiptViewModel model)
    {
        foreach (var modelValue in ModelState.Values)
        {
            modelValue.Errors.Clear();
        }
        
        var contract = await _contractService.GetAsync<PreviewContractViewModel>(model.ContractId);
        model.FullName = contract.CustomerDetail.FullName;
        model.Address = contract.CustomerDetail.TempAccommodation;
        return View("Add", model);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddReceiptViewModel model)
    {
        var invoiceId = await _receiptService.AddAsync(model).ConfigureAwait(false);
        return RedirectToAction("Preview", new { id = invoiceId });
    }

    public async Task<IActionResult> Preview(int id)
    {
        var model = await _receiptService.GetAsync<PreviewReceiptViewModel>(id).ConfigureAwait(false);
        return View(model);
    }
    
    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _receiptService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _receiptService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }
}
