using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;
[Authorize(Roles = $"{Role.Admin},{Role.Accountant},{Role.ParkingAttendant},{Role.SalesRepresentative}")]
public class HomeController : AreaControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}