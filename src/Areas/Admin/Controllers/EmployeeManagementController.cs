using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.EmployeeManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.Admin))]
public class EmployeeManagementController : AreaControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeManagementController(IEmployeeService featureService)
    {
        _employeeService = featureService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _employeeService.ListAsync<ListEmployeeViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddEmployeeViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString()
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddEmployeeViewModel model)
    {
        await _employeeService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return View(model);
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _employeeService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _employeeService.GetAsync<EditEmployeeViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditEmployeeViewModel model)
    {
        await _employeeService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
}