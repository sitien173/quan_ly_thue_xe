using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel;
using CarRentalManagement.Models.ViewModel.DamagesManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.ParkingAttendant))]
public class DamagesManagementController : AreaControllerBase
{
    private readonly IDamagesService _damagesService;
    private readonly IEmployeeService _employeeService;

    public DamagesManagementController(IDamagesService damagesService, IEmployeeService employeeService)
    {
        _damagesService = damagesService;
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _damagesService.ListAsync<ListDamagesViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddDamagesViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CreatedBy = UserId,
            DamagedAt = DateTime.Now,
            Content = Constant.DamagesContentTemplate
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddDamagesViewModel model)
    {
        var id = await _damagesService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return RedirectToAction("Preview", new { id });
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _damagesService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _damagesService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Preview([FromRoute] int id)
    {
        var model = await _damagesService
            .GetAsync<PreviewDamagesViewModel>(id)
            .ConfigureAwait(false);
        
        var employeeFullName = await _employeeService.GetAsync<EmployeeFullName>(model.CreatedBy).ConfigureAwait(false);
        model.CreatedByFullName = employeeFullName.FullName;

        return View(model);
    }
}