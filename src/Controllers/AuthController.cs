﻿using System.Security.Claims;
using AutoMapper;
using CarRentalManagement.Common;
using CarRentalManagement.Interceptors.Filter;
using CarRentalManagement.Models.Settings;
using CarRentalManagement.Models.ViewModel.Auth;
using CarRentalManagement.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CarRentalManagement.Controllers;

[HandlerException]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly CookiesSettings _cookiesSettings;

    public AuthController(IAuthService authService, IOptions<CookiesSettings> options)
    {
        _authService = authService;
        _cookiesSettings = options.Value;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        var model = new LoginViewModel
        {
            ReturnUrl = returnUrl ?? Url.Action("Index", "Home")
        };

        if (returnUrl?.Contains(AreaManager.Admin, StringComparison.OrdinalIgnoreCase) ?? false)
        {
            return View("Login2", model);
        }
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginViewModel model)
    {
        var claimsPrincipal = await _authService.LoginAsync(model).ConfigureAwait(false);
        await SignInAsync(model, claimsPrincipal).ConfigureAwait(false);

        return Redirect(model.ReturnUrl!);
    }

    private async Task SignInAsync(LoginViewModel model, ClaimsPrincipal claimsPrincipal)
    {
        await HttpContext.SignInAsync(_cookiesSettings.AuthenticationScheme,
            claimsPrincipal,
            new AuthenticationProperties
                { IsPersistent = model.RememberMe }).ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> Login2([FromForm] LoginViewModel model)
    {
        var claimsPrincipal = await _authService.LoginAsync(model, LoginMode.Employee).ConfigureAwait(false);
        await SignInAsync(model, claimsPrincipal).ConfigureAwait(false);
        
        return Redirect(model.ReturnUrl!);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(_cookiesSettings.AuthenticationScheme).ConfigureAwait(false);
        return RedirectToAction("Login", new {returnUrl = Request.Headers["Referer"].ToString()});
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        var model = new RegistrationViewModel
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            LicenseViewModels = new ()
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegistrationViewModel model)
    {
        await _authService.CreateAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Đăng ký thành công, vui lòng kiểm tra email để xác nhận tài khoản");
        return RedirectToAction("WaitConfirm");
    }
    
    [HttpGet]
    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult ChangePassword()
    {
        var model = new ChangePasswordViewModel
        {
            ReturnUrl = Request.Headers["Referer"].ToString(),
            CustomerId = UserId
        };
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    [HandlerException]
    public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordViewModel model)
    {
        await _authService.ChangePasswordAsync(model).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Đổi mật khẩu thành công, vui lòng đăng nhập lại");
        return RedirectToAction("Logout");
    }
    
    [HttpGet]
    public IActionResult WaitConfirm()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetPassword([FromForm] string email)
    {
        await _authService.ResetPasswordAsync(email).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Vui lòng kiểm tra email để lấy lại mật khẩu");
        return RedirectToAction("WaitConfirm");
    }

    [HttpGet]
    public async Task<IActionResult> Verify([FromQuery] string token)
    {
        await _authService.VerifyAsync(token).ConfigureAwait(false);
        _ = TempData.TryAdd("Message", "Xác minh tài khoản thành công, vui lòng đăng nhập lại");
        return RedirectToAction("Login");
    }
}