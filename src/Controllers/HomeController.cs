using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.ViewModel;
using CarRentalManagement.Models.ViewModel.Home;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Controllers;

public class HomeController : BaseController
{
    private readonly ICarService _carService;
    private readonly IContactService _contactService;
    public const string Key = nameof(CarFilterResponseViewModel);
    public HomeController(ICarService carService, IContactService contactService)
    {
        _carService = carService;
        _contactService = contactService;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 12)
    {
        var model = new CarFilterViewModel(){PageNumber = pageNumber, PageSize = pageSize};
        var filterCars = await _carService.FilterCarsAsync(model).ConfigureAwait(false);
        ViewData.Add(Key, filterCars);
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Index([FromForm] CarFilterViewModel model, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        model.PageNumber = pageNumber;
        model.PageSize = pageSize;
        var filterCars = await _carService.FilterCarsAsync(model).ConfigureAwait(false);
        ViewData.Add(Key, filterCars);
        return View(model);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View(new AddContactViewModel());
    }
    
    [HttpPost]
    [HandlerException]
    public async Task<IActionResult> Contact([FromForm] AddContactViewModel model)
    {
        await _contactService.AddAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Cảm ơn bạn đã gửi liên hệ cho chúng tôi. Chúng tôi sẽ liên hệ lại với bạn trong thời gian sớm nhất.");
        return View(model);
    }

    public IActionResult AboutUs()
    {
        return View();
    }
}