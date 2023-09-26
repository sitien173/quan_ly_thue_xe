using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Models.ViewModel.Home;

public class CarFilterViewModel
{
    public CarFilterViewModel()
    {
        FeatureIds = Array.Empty<int>();
    }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    [Display(Name = "Tìm kiếm tên xe")]
    [DataType(DataType.Password)]
    public string? TxtText { get; set; }
    
    [Display(Name = "Truyền động")]
    public TransmissionEnum? TransmissionEnum { get; set; }
    
    [Display(Name = "Nhiên liệu")]
    public FuelEnum? FuelEnum { get; set; }
    
    [Display(Name = "Số chỗ")]
    public int? Seat { get; set; } 
    
    [Display(Name = "Năm sản xuất")]
    public int? ManufactureYear { get; set; } 
    
    [Display(Name = "Thuong hiệu")]
    public int? BrandId { get; set; } 
    
    [Display(Name = "Loại xe")]
    public int? CarTypeId { get; set; } 
    
    [Display(Name = "Tính năng")]
    public int[] FeatureIds { get; set; } 
    
    [Display(Name = "Ngày thuê")]
    [DataType(DataType.Date)]
    public DateTime? RentalDate { get; set; }
    
    [Display(Name = "Ngày trả")]
    [DataType(DataType.Date)]

    public DateTime? ReturnedDate { get; set; }
}