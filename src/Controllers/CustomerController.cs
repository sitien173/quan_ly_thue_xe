using CarRentalManagement.Models.ViewModel.Customer;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Controllers;

[Authorize]
public class CustomerController : BaseController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    public async Task<IActionResult> EditInformation()
    {
        var model = await _customerService.GetAsync<CustomerInformationViewModel>(UserId).ConfigureAwait(false);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditInformation([FromForm] CustomerInformationViewModel model)
    {
        await _customerService.UpdateInformation(model, UserId).ConfigureAwait(false);
        return RedirectToAction("EditInformation");
    }
    
    public async Task<IActionResult> FollowCars()
    {
        var model = await _customerService.GetAsync<CarFollowViewModel>(UserId).ConfigureAwait(false);
        return View(model);
    }
}