using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Extensions;

namespace CarRentalManagement.Models.ViewModel.CustomerManagement;

public class ListCustomerViewModel
{
    [Display(Name = "Mã")]
    public int Id { get; set; }
    
    [Display(Name= "Họ")]
    public string FirstName { get; set; }
    
    [Display(Name= "Tên")]
    public string LastName { get; set; }
    
    [Display(Name= "Giới tính")]
    public SexEnum SexEnum { get ; set; }
    
    [Display(Name = "Giới tính")] public string SexEnumDescription => SexEnum.GetDescription();

    [Display(Name= "Ngày sinh")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    
    public DateTime BirthDate { get; set; }
    
    [Display(Name= "Số điện thoại")]
    public string Phone { get; set; }
    
    [Display(Name= "Email")]
    public string Email { get; set; }
    
    [Display(Name= "Số CCCD")]
    public string IDCard { get; set; }
    
    [Display(Name= "Nơi ở hiện tại")]
    public string CurrentAddress { get; set; }
    
    [Display(Name= "Nghề nghiệp")]
    public string Profession { get; set; }
    
    [Display(Name= "Đã xác thực")]
    public bool IsVerify { get; set; }
    
    [Display(Name= "Đã khoá")]
    public bool IsLocked { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Customer, ListCustomerViewModel>();
        }
    }
}