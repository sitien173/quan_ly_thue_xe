using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.EmployeeManagement;

public class EditEmployeeViewModel
{
    [HiddenInput]
    
    public int Id { get; set; }
    [HiddenInput]
    
    public string? ReturnUrl { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên không được để trống")]
    [Display(Name = "Họ tên")]
    public string FullName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được để trống")]
    [Display(Name = "Tên đăng nhập")]
    public string UserName { get; set; }
    
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
            CreateMap<EditEmployeeViewModel, Employee>().ReverseMap();
        }
    }
}