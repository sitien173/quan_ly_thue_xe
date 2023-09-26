using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Extensions;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.EmployeeManagement;

public class ListEmployeeViewModel
{
    [Display(Name = "Mã")]
    public int Id { get; set; }
    
    [Display(Name = "Họ tên")]
    public string FullName { get; set; }
    
    [Display(Name = "Tên đăng nhập")]
    public string UserName { get; set; }
    
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }
    
    [Display(Name = "Giới tính")]
    public SexEnum SexEnum { get; set; }

    [Display(Name = "Giới tính")] 
    public string SexEnumDescription => SexEnum.GetDescription();
    
    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    
    public DateTime? BirthDate { get; set; }
    
    [Display(Name = "Vai trò")]
    public RoleEnum RoleEnum { get; set; }
    
    [Display(Name = "Vai trò")]
    public string RoleEnumDescription => RoleEnum.GetDescription();

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, ListEmployeeViewModel>();
        }
    }
}