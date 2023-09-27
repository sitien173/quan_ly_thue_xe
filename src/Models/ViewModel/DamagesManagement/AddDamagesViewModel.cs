using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.DamagesManagement;

public class AddDamagesViewModel
{
    [Display(Name = "Mã hợp đồng")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã hợp đồng không được để trống")]
    public int ContractId { get; set; }
    
    [Display(Name = "Chi phí sửa chữa")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Chi phí sửa chữa không được để trống")]
    public decimal TotalRepairCost { get; set; }
    
    [Display(Name = "Ngày hư hỏng")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Ngày hư hỏng không được để trống")]
    public DateTime DamagedAt { get; set; }
    
    [Display(Name = "Mô tả")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả không được để trống")]
    public string Content { get; set; } = null!;
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    [HiddenInput]
    public int CreatedBy { get; set; }
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddDamagesViewModel, Damages>();
        }
    }
}