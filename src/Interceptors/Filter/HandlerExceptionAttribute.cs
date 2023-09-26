using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarRentalManagement.Interceptors.Filter;

public class HandlerExceptionAttribute : ActionFilterAttribute
{
    public string? ReturnView { get; init; }
    public string? RedirectToLocalAction { get; init; }
    public string? RedirectToUrl { get; init; }
    public object? RouteValues { get; init; }
    public override void OnActionExecuting(ActionExecutingContext context)
    {

        if (context.HttpContext.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase) ||
            !context.HttpContext.Request.HasFormContentType || context.ModelState.IsValid)
        {
            base.OnActionExecuting(context);
            return;
        }
        
        var controller = (Controller) context.Controller;
        var contextActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
        
        context.Result = getActionResult(controller, contextActionDescriptor);
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var controller = (Controller) context.Controller;
        var contextActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
        
        if (context.Exception is ArgumentException e)
        {
            var message = Regex.Replace(e.Message, "\\(Parameter.*\\)", string.Empty);
            controller.TempData.TryAdd("Message", message);
            context.ModelState.TryAddModelError(e.ParamName ?? "Message", message);
            context.ExceptionHandled = true;
        }
        
        if (!context.ExceptionHandled)
        {
            base.OnActionExecuted(context);
            return;
        }
        
        context.Result = getActionResult(controller, contextActionDescriptor);
        base.OnActionExecuted(context);
    }
    
    private IActionResult getActionResult(Controller controller, ControllerActionDescriptor contextActionDescriptor)
    {
        if (!string.IsNullOrEmpty(RedirectToLocalAction))
        {
            return new RedirectToActionResult
                ( RedirectToLocalAction ?? contextActionDescriptor.ActionName, contextActionDescriptor.ControllerName, RouteValues);
        }

        if (!string.IsNullOrEmpty(RedirectToUrl))
        {
            return new RedirectResult(RedirectToUrl);
        }
        
        return new ViewResult()
        {
            ViewName = ReturnView ?? contextActionDescriptor.ActionName,
            ViewData = controller.ViewData,
            TempData = controller.TempData
        };
    }
}