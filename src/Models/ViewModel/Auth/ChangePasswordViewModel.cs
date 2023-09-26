using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.Auth;

public class ChangePasswordViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu hiện tại không được để trống")]
    [Display(Name = "Mật khẩu hiện tại", Prompt = "Nhập mật khẩu hiện tại")]
    public string CurrentPassword { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu mới không được để trống")]
    [Display(Name = "Mật khẩu mới", Prompt = "Nhập mật khẩu mới")]
    public string NewPassword { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Xác nhận mật khẩu không được để trống")]
    [Display(Name = "Xác nhận mật khẩu", Prompt = "Nhập lại mật khẩu mới")]
    [Compare(nameof(NewPassword), ErrorMessage = "Xác nhận mật khẩu không khớp")]
    public string ConfirmPassword { get; set; }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [HiddenInput]
    public int CustomerId { get; set; }
}