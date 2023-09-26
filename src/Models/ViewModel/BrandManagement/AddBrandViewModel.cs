using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.BrandManagement;

public class AddBrandViewModel
{
    [Display(Name = "Tên thương hiệu")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên thương hiệu không được để trống")]
    public string Name { get; set; }
    
    [Display(Name = "Tên viết tắt")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên viết tắt không được để trống")]
    public string Code { get; set; }
    
    [Display(Name = "Ngày phát hành")]
    [DataType(DataType.Date)]
    public DateTime? ReleaseAt { get; set; } 
    
    [Display(Name = "Quốc gia")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Quốc gia không được để trống")]
    public string Country { get; set; }
    public string? ReturnUrl { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddBrandViewModel, Brand>();
        }
    }
}