using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.EmployeeManagement;

public class AddEmployeeViewModel
{
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên không được để trống")]
    [Display(Name = "Họ tên")]
    public string FullName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được để trống")]
    [Display(Name = "Tên đăng nhập")]
    public string UserName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được để trống")]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Xác nhận mật khẩu không được để trống")]
    [Display(Name = "Xác nhận mật khẩu")]
    [Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp")]
    public string ConfirmPassword { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được để trống")]
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Giới tính không được để trống")]
    [Display(Name = "Giới tính")]
    public SexEnum SexEnum { get; set; }
    
    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]

    
    public DateTime? BirthDate { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Vai trò không được để trống")]
    [Display(Name = "Vai trò")]
    public RoleEnum RoleEnum { get; set; }
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddEmployeeViewModel, Employee>()
                .ForMember(x => x.Password, opt =>
                    opt.MapFrom(x => PasswordHelper.HashPassword(x.Password)));
        }
    }
    
}