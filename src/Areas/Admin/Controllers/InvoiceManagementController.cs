using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.InvoiceManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Roles = Role.Accountant)]
public class InvoiceManagementController : AreaControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceManagementController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _invoiceService.ListAsync<ListInvoiceViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult PrepareAdd()
    {
        return View();
    }

    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> PrepareAdd([FromForm] int contractId)
    {
        var model = await _invoiceService.PrepareAddAsync(contractId).ConfigureAwait(false);
        model.ReturnUrl = Request.Headers["Referer"].ToString();
        return View("Add", model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddInvoiceViewModel model)
    {
        var invoiceId = await _invoiceService.AddAsync(model).ConfigureAwait(false);
        return RedirectToAction("Preview", new { id = invoiceId });
    }

    public async Task<IActionResult> Preview(int id)
    {
        var model = await _invoiceService.GetAsync<PreviewInvoiceViewModel>(id).ConfigureAwait(false);
        return View(model);
    }
    
    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _invoiceService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _invoiceService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }
}