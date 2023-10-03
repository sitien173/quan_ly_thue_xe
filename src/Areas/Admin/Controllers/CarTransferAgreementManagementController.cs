using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel;
using CarRentalManagement.Models.ViewModel.CarTransferAgreementManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Policy = nameof(PolicyEnum.ParkingAttendant))]
public class CarTransferAgreementManagementController : AreaControllerBase
{
    private readonly ICarTransferAgreementService _carTransferAgreementService;
    private readonly IEmployeeService _employeeService;

    public CarTransferAgreementManagementController(ICarTransferAgreementService carTransferAgreementService, IEmployeeService employeeService)
    {
        _carTransferAgreementService = carTransferAgreementService;
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _carTransferAgreementService.ListAsync<ListCarTransferAgreementViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddCarTransferAgreementViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CreatedBy = UserId,
            CreatedAt = DateTime.Now,
            EquipmentAttend = Constant.CarTransferAgreementEquipmentAttendTemplate,
            TestListDetail = Constant.CarTransferAgreementTestListDetailTemplate,
            VehicleProfileSetAttend = Constant.CarTransferAgreementVehicleProfileSetAttendTemplate
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddCarTransferAgreementViewModel model)
    {
        model.CreatedBy = UserId;
        model.CreatedAt = DateTime.Now;
        var id = await _carTransferAgreementService.AddAsync(model).ConfigureAwait(false);
        return RedirectToAction("Preview", new { id });
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _carTransferAgreementService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _carTransferAgreementService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    public async Task<IActionResult> Preview([FromRoute] int id)
    {
        var model = await _carTransferAgreementService
            .GetAsync<PreviewCarTransferAgreementViewModel>(id)
            .ConfigureAwait(false);
        
        var employeeFullName = await _employeeService.GetAsync<EmployeeFullName>(model.CreatedBy).ConfigureAwait(false);
        model.CreatedByFullName = employeeFullName.FullName;

        return model.CheckInOutEnum == CheckInOutEnum.In ? View("PreviewIn", model) : View("PreviewOut", model);
    }
}