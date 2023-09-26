using System.Diagnostics;
using CarRentalManagement.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Controllers;

public class ErrorController : Controller
{
    public new IActionResult NotFound() => View();
    public IActionResult AccessDenied() => View();
    
    [HttpGet]
    public IActionResult HandleError([FromQuery] int? code = null) => code switch
    {
        404 => RedirectToAction("NotFound"),
        403 => RedirectToAction("AccessDenied"),
        _ => View("Index", new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            Message = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error.Message
        })
    };
}