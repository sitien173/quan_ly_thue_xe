using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.SurChargeManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Roles = Role.Accountant)]
public class SurChargeManagementController : AreaControllerBase
{
    private readonly ISurChargeService _surChargeService;
    public SurChargeManagementController(ISurChargeService surChargeService)
    {
        _surChargeService = surChargeService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _surChargeService.ListAsync<ListSurChargeViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddSurChargeViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString()
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddSurChargeViewModel model)
    {
        await _surChargeService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return View(model);
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _surChargeService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _surChargeService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _surChargeService.GetAsync<EditSurChargeViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditSurChargeViewModel model)
    {
        await _surChargeService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
}