using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CarRentalManagement.Models.ViewModel.SurChargeManagement;

public class ListSurChargeViewModel
{
    [Display(Name = "Mã phụ giá")]
    public int Id { get; set; }
    
    [Display(Name = "Tên phụ giá")]
    public string Name { get; set; }
    
    [Display(Name = "Giá phụ giá")]
    public string Price { get; set; }
    
    [Display(Name = "Loại xe")]
    public string CarTypeName { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.SurCharge, ListSurChargeViewModel>();
        }
    }
}