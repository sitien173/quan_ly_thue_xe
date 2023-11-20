using System.ComponentModel.DataAnnotations;
using CarRentalManagement.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.Car;

public class RentCarViewModel
{
    [Display(Name = "Ngày thuê")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ngày thuê không được để trống")]
    public DateTime StartDate { get; set; }
        
    [Display(Name = "Ngày trả")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ngày trả không được để trống")]
    [DateGreaterThan("StartDate", ErrorMessage = "Ngày trả phải lớn hơn ngày thuê")]
    public DateTime EndDate { get; set; } 
        
    [HiddenInput]
    public int CarId { get ; set; }
    
    [HiddenInput]
    public int CustomerId { get ; set; }
    
    [Display(Name = "Loại thuê")]
    public int EstimateId { get ; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }
}