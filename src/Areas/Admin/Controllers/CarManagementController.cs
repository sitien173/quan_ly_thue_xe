using CarRentalManagement.Common;
using CarRentalManagement.Controllers;
using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel.CarGallery;
using CarRentalManagement.Models.ViewModel.CarManagement;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Authorize(Roles = Role.ParkingAttendant)]
public class CarManagementController : AreaControllerBase
{
    private readonly ICarService _carService;
    public CarManagementController(ICarService featureService)
    {
        _carService = featureService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _carService.ListAsync<ListCarViewModel>().ConfigureAwait(false);
        return View(model);
    }
    
    public IActionResult Add()
    {
        return View(new AddCarViewModel()
        {
            ReturnUrl = Request.Headers["Referer"].ToString()
        });
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Add([FromForm] AddCarViewModel model)
    {
        await _carService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Thêm thành công");
        return View(model);
    }

    [HttpGet]
    [HandlerException]
    public async Task<IActionResult> Delete(int id)
    {
        await _carService.DeleteAsync(id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xoá thành công 1 bản ghi");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Delete(IEnumerable<int> ids)
    {
        int rowEffected = await _carService.DeleteAsync(ids).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", $"Xoá thành công {rowEffected} bản ghi");
        return Ok();
    }

    [HttpGet]
    [HandlerException(RedirectToLocalAction = "Index")]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var editModel = await _carService.GetAsync<EditCarViewModel>(id).ConfigureAwait(false);
        editModel.ReturnUrl = Request.Headers["Referer"].ToString();
        return View(editModel);
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Edit([FromForm] EditCarViewModel model)
    {
        await _carService.UpdateAsync(model, model.Id).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cập nhật thành công");
        return View(model);
    }
    
    [HttpGet("[area]/[controller]/{id}/[action]")]
    public async Task<IActionResult> CarGalleries(int id)
    {
        var carGalleryViewModels = await _carService.GetCarGalleriesAsync(id).ConfigureAwait(false);
        var model = new EditCarGalleryViewModel()
        {
            CarId = id,
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CarGalleryViewModels = carGalleryViewModels
        };
        
        model.ChangeCarGalleryViewModels.AddRange(carGalleryViewModels.Select(x => new EditCarGalleryViewModel.ChangeCarGalleryViewModel(){Id = x.Id}));
        return View(model);
    }
    
    [HttpPost("[area]/[controller]/{id}/[action]")]
    public async Task<IActionResult> CarGalleries([FromForm] EditCarGalleryViewModel model)
    {
        await _carService.EditCarGalleriesAsync(model).ConfigureAwait(false);
        return RedirectToAction("CarGalleries", new { id = model.CarId });
    }
}