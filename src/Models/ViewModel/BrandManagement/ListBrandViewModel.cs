using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.BrandManagement;

public class ListBrandViewModel
{
    [Display(Name = "Mã thương hiệu")]
    public int Id { get; set; }
    [Display(Name = "Tên thương hiệu")]
    public string Name { get; set; }
    [Display(Name = "Viết tắt")]
    public string Code { get; set; }
    
    [Display(Name = "Ngày phát hành")]
    
    public DateTime ReleaseAt { get; set; }
    [Display(Name = "Quốc gia")]
    public string Country { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Brand, ListBrandViewModel>();
        }
    }
}