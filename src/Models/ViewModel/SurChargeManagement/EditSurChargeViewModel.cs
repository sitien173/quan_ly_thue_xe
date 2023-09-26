using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.SurChargeManagement;

public class EditSurChargeViewModel
{
    [HiddenInput]
    
    public int Id { get; set; }
    
    [HiddenInput]
    
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Tên phụ giá")]
    [Required(ErrorMessage = "Tên phụ giá không được để trống")]
    public string Name { get; set; }
    
    [Display(Name = "Giá phụ giá")]
    [Required(ErrorMessage = "Giá phụ giá không được để trống")]
    [DataType(DataType.Text)]
    public decimal Price { get; set; }
    
    [Display(Name = "Loại xe")]
    public int CarTypeId { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<EditSurChargeViewModel, Entities.SurCharge>()
                .ReverseMap();
        }
    }
}