using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.Auth;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được để trống")]
    [Display(Name = "Tên đăng nhập", Prompt = "Nhập tên đăng nhập")]
    public string UserName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu", Prompt = "Nhập mật khẩu")]
    public string Password { get; set; }
    
    [Display(Name = "Ghi nhớ đăng nhập")]
    public bool RememberMe { get; set; }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
}