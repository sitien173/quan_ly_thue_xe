using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.CustomerManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.Admin))]
public class CustomerManagementController : AreaControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerManagementController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _customerService.ListAsync<ListCustomerViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _customerService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _customerService.GetAsync<EditCustomerViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditCustomerViewModel model)
    {
        await _customerService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
}