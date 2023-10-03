using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.IncidentReportsManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.SalesRepresentative))]
public class IncidentReportsManagementController : AreaControllerBase
{
    private readonly IIncidentReportsService _incidentReportsService;

    public IncidentReportsManagementController(IIncidentReportsService incidentReportsService)
    {
        _incidentReportsService = incidentReportsService;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _incidentReportsService.ListAsync<ListIncidentReportsViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddIncidentReportsViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CreatedBy = UserId,
            ReportDate = DateTime.Now
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddIncidentReportsViewModel model)
    {
        await _incidentReportsService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return View(model);
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _incidentReportsService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _incidentReportsService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _incidentReportsService.GetAsync<EditIncidentReportsViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditIncidentReportsViewModel model)
    {
        await _incidentReportsService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
}