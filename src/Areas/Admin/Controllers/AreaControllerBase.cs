using CarRentalManagement.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Areas.Admin.Controllers;

[Area(AreaManager.Admin)]
[Authorize]
public class AreaControllerBase : BaseController
{
    
}