using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Extensions;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.EstimateManagement;

public class ListEstimateViewModel
{
    [Display(Name = "Mã")]
    public int Id { get; set; }
    
    [Display(Name = "Loại xe")]
    public string CarTypeName { get; set; }
    
    [Display(Name = "Đơn vị tính")]
    public RentalMethodEnum RentalMethod { get; set; }
    
    public string RentalMethodDescription => RentalMethod.GetDescription();

    [Display(Name = "Đơn giá")]
    public string UnitPrice { get; set; }
    
    [Display(Name = "Ngày áp dụng")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    public DateTime UpdatedAt { get; set; }
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Estimate, ListEstimateViewModel>();
        }
    }
    
}