using CarRentalManagement.Models.ViewModel.Report;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRentalManagement.Areas.Admin.Controllers;

public class ReportController : AreaControllerBase
{
    private readonly IReportService _reportService;
    private readonly ICarService _carService;

    public const string TopCarRent = "TopCarRent";
    
    // GET
    public ReportController(IReportService reportService, ICarService carService)
    {
        _reportService = reportService;
        _carService = carService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData[TopCarRent] = await _carService.GetTopCarRentAsync().ConfigureAwait(false);
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Revenue([FromForm] RevenueRequest request)
    {
        var model = await _reportService.GetRevenueAsync(request).ConfigureAwait(false);
        return Ok(JsonConvert.SerializeObject(model, Formatting.None));
    }
}