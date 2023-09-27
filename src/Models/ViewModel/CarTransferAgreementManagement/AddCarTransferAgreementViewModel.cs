using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.CarTransferAgreementManagement;

public class AddCarTransferAgreementViewModel
{
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Danh mục kiểm tra")]
    public string? TestListDetail { get; set; }
    
    [Display(Name = "Trang thiết bị đi kèm")]
    public string? EquipmentAttend { get; set; }
    
    [Display(Name = "Hồ sơ xe đi kèm")]
    public string? VehicleProfileSetAttend { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)]
    [HiddenInput]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    [Display(Name = "Người tạo")]
    [HiddenInput]
    public int CreatedBy { get; set; }
    
    [Display(Name = "Xe ra/vào bãi")]
    public CheckInOutEnum CheckInOutEnum { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddCarTransferAgreementViewModel, CarTransferAgreement>();
        }
    }
}