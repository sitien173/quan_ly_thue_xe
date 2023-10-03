using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.FeatureManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.ParkingAttendant))]
public class FeatureManagementController : AreaControllerBase
{
    private readonly IFeatureService _featureService;
    public FeatureManagementController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _featureService.ListAsync<ListFeatureViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddFeatureViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString()
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddFeatureViewModel model)
    {
        await _featureService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return View(model);
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _featureService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _featureService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _featureService.GetAsync<EditFeatureViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditFeatureViewModel model)
    {
        await _featureService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
}