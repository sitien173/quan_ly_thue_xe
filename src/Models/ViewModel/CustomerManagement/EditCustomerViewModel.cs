using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.CustomerManagement;

public class EditCustomerViewModel
{
    [HiddenInput]
    public int Id { get; set; }
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name= "Họ")]
    [Required(ErrorMessage = "Họ không được để trống", AllowEmptyStrings = false)]
    public string FirstName { get; set; }
    
    [Display(Name= "Tên")]
    [Required(ErrorMessage = "Tên không được để trống", AllowEmptyStrings = false)]
    public string LastName { get; set; }
    
    [Display(Name= "Ngày sinh")]
    [DataType(DataType.Date)]

    public DateTime BirthDate { get; set; }
    
    [Display(Name= "Số điện thoại")]
    [Required(ErrorMessage = "Số điện thoại không được để trống", AllowEmptyStrings = false)]
    public string Phone { get; set; }
    
    [Display(Name= "Email")]
    [Required(ErrorMessage = "Email không được để trống", AllowEmptyStrings = false)]
    public string Email { get; set; }
    
    [Display(Name= "Nơi thường trú")]
    [Required(ErrorMessage = "Nơi ở không được để trống", AllowEmptyStrings = false)]
    public string Domicile { get; set; }
    
    [Display(Name= "Nơi tạm trú")]
    [Required(ErrorMessage = "Nơi tạm trú không được để trống", AllowEmptyStrings = false)]
    public string TempAccommodation { get; set; }
    
    [Display(Name= "Nơi ở hiện tại")]
    [Required(ErrorMessage = "Nơi ở hiện tại không được để trống", AllowEmptyStrings = false)]
    public string CurrentAddress { get; set; }
    
    [Display(Name= "Nghề nghiệp")]
    [Required(ErrorMessage = "Nghề nghiệp không được để trống", AllowEmptyStrings = false)]
    public string Profession { get; set; }
    
    [Display(Name= "Nơi làm việc")]
    [Required(ErrorMessage = "Nơi làm việc không được để trống", AllowEmptyStrings = false)]
    public string WorkPlace { get; set; }
    
    [ReadOnly(true)]
    [Display(Name= "Tên đăng nhập")]
    [Required(ErrorMessage = "Tên đăng nhập không được để trống", AllowEmptyStrings = false)]
    public string UserName { get; set; }
    
    [Display(Name= "Đã xác thực")]
    public bool IsVerify { get; set; }
    
    [Display(Name= "Đã khoá")]
    public bool IsLocked { get; set; }
    
    [ReadOnly(true)]
    [HiddenInput]
    [Display(Name= "Ảnh đại diện")]
    public string Avatar { get; set; }
    
    [HiddenInput]
    public string? AvatarThumb { get; set; }

    [ReadOnly(true)]
    [Display(Name= "Ngày tạo")]
    [DataType(DataType.Date)]

    public DateTime? CreatedAt { get; set; }
    
    [Display(Name= "Giới tính")]
    public SexEnum SexEnum { get ; set; }
    
    [ReadOnly(true)]
    [Display(Name= "Số CCCD")]
    [Required(ErrorMessage = "Số CCCD không được để trống", AllowEmptyStrings = false)]
    public string IDCard { get; set; }
    
    [ReadOnly(true)]
    [Display(Name= "Ngày cấp")]
    [DataType(DataType.Date)]

    [Required(ErrorMessage = "Ngày cấp không được để trống", AllowEmptyStrings = false)]
    public DateTime DateOfIssue { get; set; }
    
    [ReadOnly(true)]
    [Display(Name= "Nơi cấp")]
    [Required(ErrorMessage = "Nơi cấp không được để trống", AllowEmptyStrings = false)]
    public string PlaceOfIssue { get; set; }
    
    [ReadOnly(true)]
    [Display(Name= "Ngày hết hạn")]
    [DataType(DataType.Date)]

    [Required(ErrorMessage = "Ngày hết hạn không được để trống", AllowEmptyStrings = false)]
    public DateTime ExpirationDate { get; set; }
    
    [HiddenInput]
    [Display(Name= "Ảnh mặt trước CCCD")]
    public string FrontalPhoto { get; set; }
    
    [HiddenInput]
    public string FrontalPhotoThumb { get; set; }
    
    [HiddenInput]
    [Display(Name= "Ảnh mặt sau CCCD")]
    public string RearPhoto { get; set; }
    [HiddenInput]
    public string RearPhotoThumb { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<EditCustomerViewModel, Entities.Customer>().ReverseMap();
        }
    }
}