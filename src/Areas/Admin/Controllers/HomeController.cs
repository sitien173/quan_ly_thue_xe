using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;
[Authorize(Policy = nameof(PolicyEnum.All))]
public class HomeController : AreaControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}