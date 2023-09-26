using CarRentalManagement.Models.ViewModel.Car;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Controllers;

public class CarController : BaseController
{
    private readonly ICarService _carService;
    public const string CarDetailData = nameof(CarDetailData);
    public const string Message = nameof(Message);
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("[controller]/{id}")]
    public async Task<IActionResult> Index([FromRoute] int id)
    {
        var carDetail = await _carService.GetAsync<CarDetailViewModel>(id).ConfigureAwait(false);
        ViewData.Add(CarDetailData, carDetail);
        
        var model = new RentCarViewModel()
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            CarId = id
        };
        
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Rent([FromForm] RentCarViewModel model)
    {
        string message;
        try
        {
            model.CustomerId = UserId;
            await _carService.RentCarAsync(model).ConfigureAwait(false);
            message = "Đặt xe thành công, vui lòng đợi xác nhận từ nhân viên";
        }
        catch (ArgumentException e)
        {
            message = e.Message;
        }
        
        _ = TempData.TryAdd(Message,message);
        return RedirectToAction("Index", new { id = model.CarId });
    }

    [Authorize]
    public async Task<IActionResult> Follow(int id)
    {
        await _carService.FollowCarAsync(id, UserId).ConfigureAwait(false);
        return Ok();
    }
    
    [Authorize]
    public async Task<IActionResult> DeleteFollow(int id)
    {
        await _carService.UnFollowCarAsync(id, UserId).ConfigureAwait(false);
        return Ok();
    }
    
}