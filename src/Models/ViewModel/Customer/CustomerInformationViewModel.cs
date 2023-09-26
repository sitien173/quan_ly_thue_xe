using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.Customer;

public class CustomerInformationViewModel
{
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Họ không được để trống")]
    [Display(Name = "Họ", Prompt = "Nhập họ", Description = "Họ là bắt buộc")]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được để trống")]
    [Display(Name = "Tên", Prompt = "Nhập tên", Description = "Tên là bắt buộc")]
    public string LastName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày sinh không được để trống")]
    [DataType(DataType.Date, ErrorMessage = "Ngày sinh không hợp lệ")]
    [Display(Name = "Ngày sinh", Prompt = "Nhập ngày sinh", Description = "Ngày sinh là bắt buộc")]
    public DateTime BirthDate { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Số điện thoại không được để trống")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [Display(Name = "Số điện thoại", Prompt = "Nhập số điện thoại", Description = "Số điện thoại là bắt buộc")]
    public string Phone { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Display(Name = "Email", Prompt = "Nhập email", Description = "Email là bắt buộc")]
    public string Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi thường trú không được để trống")]
    [Display(Name = "Nơi thường trú", Prompt = "Nhập nơi thường trú", Description = "Nơi thường trú là nơi công dân sinh sống thường xuyên, ổn định, không có thời hạn tại một chỗ ở nhất định và đã đăng ký thường trú")]
    public string Domicile { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi tạm trú không được để trống")]
    [Display(Name = "Nơi tạm trú", Prompt = "Nhập nơi tạm trú", Description = "Nơi tạm trú là nơi công dân sinh sống ngoài nơi đăng ký thường trú và đã đăng ký tạm trú")]
    public string TempAccommodation { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi ở hiện tại không được để trống")]
    [Display(Name = "Nơi ở hiện tại", Prompt = "Nhập nơi ở hiện tại", Description = "Nơi ở hiện tại là nơi đang sinh sống và làm việc")]  
    public string CurrentAddress { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nghề nghiệp không được để trống")]
    [Display(Name = "Nghề nghiệp", Prompt = "Nhập nghề nghiệp", Description = "Nghề nghiệp là bắt buộc")]
    public string Profession { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi làm việc không được để trống")]
    [Display(Name = "Nơi làm việc", Prompt = "Nhập nơi làm việc", Description = "Nơi làm việc là bắt buộc")]
    public string WorkPlace { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được để trống")]
    [Display(Name = "Tên đăng nhập", Prompt = "Nhập tên đăng nhập")]
    public string UserName { get; set; }
    
    [HiddenInput]
    public string Avatar { get; set; }
    [HiddenInput]
    public string AvatarThumb { get; set; }
    public IFormFile? AvatarFile { get; set; }
    
    [EnumDataType(typeof(SexEnum), ErrorMessage = "Giới tính không hợp lệ")]
    [Display(Name = "Giới tính", Prompt = "Chọn giới tính", Description = "Giới tính là bắt buộc")]
    public SexEnum SexEnum { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Số chứng minh nhân dân không được để trống")]
    [StringLength(12, MinimumLength = 9, ErrorMessage = "Số chứng minh nhân dân phải từ 9 đến 12 ký tự")]
    [Display(Name = "Số căn cuớc công dân", Prompt = "Nhập số căn cuớc công dân", Description = "Số căn cuớc công dân là bắt buộc")]
    public string IDCard { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày cấp không được để trống")]
    [DataType(DataType.Date, ErrorMessage = "Ngày cấp không hợp lệ")]
    
    [Display(Name = "Ngày cấp", Prompt = "Nhập ngày cấp", Description = "Ngày ấp là bắt buộc")]
    public DateTime DateOfIssue { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nơi cấp không được để trống")]
    [Display(Name = "Nơi cấp", Prompt = "Nhập nơi cấp", Description = "Nơi cấp là bắt buộc")]
    public string PlaceOfIssue { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày hết hạn không được để trống")]
    [DataType(DataType.Date, ErrorMessage = "Ngày hết hạn không hợp lệ")]
    [Display(Name = "Ngày hết hạn", Prompt = "Nhập ngày hết hạn", Description = "Ngày hết hạn là bắt buộc")]
    public DateTime ExpirationDate { get; set; }
    
    [Display(Name = "Ảnh mặt trước")]
    [HiddenInput]
    public string FrontalPhoto { get; set; }
    [HiddenInput]
    public string FrontalPhotoThumb { get; set; }
    public IFormFile? FrontalPhotoFile { get; set; }
    
    [Display(Name = "Ảnh mặt sau")]
    [HiddenInput]
    public string RearPhoto { get; set; }
    
    [HiddenInput]
    public string RearPhotoThumb { get; set; }
    public IFormFile? RearPhotoFile { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CustomerInformationViewModel, Entities.Customer>().ReverseMap();
        }
    }
}