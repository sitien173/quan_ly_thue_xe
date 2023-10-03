using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.IncidentReportsManagement;

public class AddIncidentReportsViewModel
{
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Required]
    [Display(Name = "Mô tả")]
    public string Description { get; set; }
    
    [Display(Name = "Thông tin bổ sung")]
    public string? AdditionalDetails  { get; set; }
    
    [Required]
    [Display(Name = "Loại báo cáo")]
    public IncidentReportsTypeEnum ReportType { get; set; }
    
    [Required]
    [Display(Name = "Ngày báo cáo")]
    [HiddenInput]
    public DateTime ReportDate { get; set; }
    
    [Required]
    [Display(Name = "Người tạo")]
    [HiddenInput]
    public int CreatedBy { get; set; }

    [HiddenInput]
    public string? ReturnUrl { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddIncidentReportsViewModel, IncidentReports>();
        }
    }
}