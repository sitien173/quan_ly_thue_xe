using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.EstimateManagement;

public class AddEstimateViewModel
{
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Loại xe")]
    public int CarTypeId { get; set; }
    
    [Display(Name = "Đơn vị tính")]
    public RentalMethodEnum RentalMethod { get; set; }
    
    [Display(Name = "Đơn giá")]
    [Required(ErrorMessage = "Đơn giá không được để trống")]
    [DataType(DataType.Text)]
    public decimal UnitPrice { get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }
    
    [Display(Name = "Ngày áp dụng")]
    [DataType(DataType.Date)]

    public DateTime UpdatedAt { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddEstimateViewModel, Estimate>();
        }
    }
}