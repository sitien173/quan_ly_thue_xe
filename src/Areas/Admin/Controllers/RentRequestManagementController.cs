using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.RentRequestManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Roles = $"{Role.SalesRepresentative}, {Role.Accountant}")]
public class RentRequestManagementController : AreaControllerBase
{
    private readonly IRentRequestService _rentRequestService;
    public RentRequestManagementController(IRentRequestService rentRequestService)
    {
        _rentRequestService = rentRequestService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _rentRequestService.ListAsync<ListRentRequestViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _rentRequestService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _rentRequestService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _rentRequestService.GetAsync<EditRentRequestViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] EditRentRequestViewModel model)
    {
        await _rentRequestService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return RedirectToAction("Edit", new { id = model.Id });
    }
}