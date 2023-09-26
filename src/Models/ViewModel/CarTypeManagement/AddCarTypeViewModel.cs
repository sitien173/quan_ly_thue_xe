using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.CarTypeManagement;

public class AddCarTypeViewModel
{
    public AddCarTypeViewModel()
    {
        EstimateIds = Array.Empty<int>();
    }
    [HiddenInput]
    
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Tên loại xe")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên loại xe không được để trống")]
    public string Name { get; set; }
    
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    [Display(Name = "Biểu tượng")]
    public string? Icon { get; set; }
    
    [Display(Name = "Bảng báo giá")]
    public int[] EstimateIds { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddCarTypeViewModel, CarType>();
        }
    }
}