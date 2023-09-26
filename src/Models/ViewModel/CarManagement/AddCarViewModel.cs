using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.CarManagement;

public class AddCarViewModel
{
    [HiddenInput] public string? ReturnUrl { get; set; }
    
    [Display(Name = "Tên xe")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên xe không được để trống")]
    public string Name { get; set; }
    
    [Display(Name = "Biển số")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Biển số không được để trống")]
    public string LicensePlate { get; set; }
    
    [Display(Name = "Số khung")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Số khung không được để trống")]
    public string VIN { get; set; }
    
    [Display(Name = "Số máy")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Số máy không được để trống")]
    public string EngineSerialNumber { get; set; }
    
    [Display(Name = "Kích thước tổng thể")]
    public string? OverallSize { get; set; }
    
    [Display(Name = "Chiều dài cơ sở")]
    public string? LongStandard { get; set; }
    
    [Display(Name = "Động cơ")]
    public string? Engine { get; set; }
    
    [Display(Name = "Dung tích bình xăng")]
    public string? CapacityTank { get; set; }
    
    [Display(Name = "Tiêu thụ nhiên liệu")]
    public string? FuelConsumption{ get; set; }
    
    [Display(Name = "Màu sắc")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Màu xe không được để trống")]
    public string Color { get; set; }
    
    [Display(Name = "Số chỗ ngồi")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Số chỗ ngồi không được để trống")]
    public int Seat { get; set; }
    
    [Display(Name = "Hộp số")]
    public TransmissionEnum TransmissionEnum { get; set; }
    
    [Display(Name = "Nhiên liệu")]
    public FuelEnum FuelEnum { get; set; }
    
    [Display(Name = "Mô tả")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
    
    [Display(Name = "Hãng xe")]
    public int BrandId { get; set; }
    [Display(Name = "Loại xe")]
    public int CarTypeId { get; set; }
    
    [Display(Name = "Tính năng")]
    [Required(ErrorMessage = "Vui lòng chọn ít nhất một tính năng")]
    public int[] FeatureIds { get; set; }
    
    [Display(Name = "Ảnh")]
    [DataType(DataType.Upload)]
    [Required(ErrorMessage = "Vui lòng chọn ít nhất một ảnh")]
    public IFormFileCollection UploadImages { get; set; }
    
    [Display(Name = "Năm sản xuất")]
    [Required(ErrorMessage = "Năm sản xuất không được để trống")]
    public int ManufactureYear { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddCarViewModel, Entities.Car>();
        }
    }
}