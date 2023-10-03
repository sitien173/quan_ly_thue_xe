using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.IncidentReportsManagement;

public class ListIncidentReportsViewModel
{
    [Display(Name = "Mã sự cố")]
    public int Id { get; set; }
    
    [Editable(false)]
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Mô tả")]
    public string Description { get; set; }
    
    [Display(Name = "Thông tin bổ sung")]
    public string? AdditionalDetails  { get; set; }
    
    [Display(Name = "Loại báo cáo")]
    public IncidentReportsTypeEnum ReportType { get; set; }
    
    [Display(Name = "Ngày báo cáo")]
    public DateTime ReportDate { get; set; }
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }
    
    [Display(Name = "Người cập nhật")]
    public int? UpdatedBy { get; set; }
    
    [Display(Name = "Cập nhật gần nhất")]
    public DateTime? UpdatedDate { get; set; }
    
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IncidentReports, ListIncidentReportsViewModel>();
        }
    }
}