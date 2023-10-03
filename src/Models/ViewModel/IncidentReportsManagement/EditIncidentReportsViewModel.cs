using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.IncidentReportsManagement;

public class EditIncidentReportsViewModel
{
    [HiddenInput]
    [Editable(false)]
    public int Id { get; set; }
    
    [Editable(false)]
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
    [Editable(false)]
    public DateTime ReportDate { get; set; }
    
    [Required]
    [Display(Name = "Người tạo")]
    [Editable(false)]
    public int CreatedBy { get; set; }
    
    [Required]
    [Display(Name = "Người cập nhật")]
    [Editable(false)]
    public int? UpdatedBy { get; set; }
    
    [Required]
    [Display(Name = "Cập nhật gần nhất")]
    [Editable(false)]
    public DateTime? UpdatedDate { get; set; }

    [HiddenInput]
    public string? ReturnUrl { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EditIncidentReportsViewModel, IncidentReports>().ReverseMap();
        }
    }
}