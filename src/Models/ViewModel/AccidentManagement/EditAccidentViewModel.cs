using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.AccidentManagement;

public class EditAccidentViewModel
{
    [HiddenInput]
    [Display(Name = "Mã tai nạn")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã tai nạn không được để trống")]
    public int Id { get; set; }
    
    [Display(Name = "Mã xe")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã xe không được để trống")]
    public int CarId { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã hợp đồng không được để trống")]
    public int ContractId { get; set; }
    
    [Display(Name = "Ngày tai nạn")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày tai nạn không được để trống")]
    public DateTime AccidentAt { get; set; }
    
    [Display(Name = "Mô tả")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả không được để trống")]
    public string Description { get; set; }
    
    [HiddenInput]
    public int CreatedBy { get; set; }
    [HiddenInput]
    public string? ReturnUrl { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Accident, EditAccidentViewModel>().ReverseMap();
        }
    }
}

