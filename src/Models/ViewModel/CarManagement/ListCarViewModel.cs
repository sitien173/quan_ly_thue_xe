using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CarRentalManagement.Models.ViewModel.CarManagement;

public class ListCarViewModel
{
    [Display(Name = "Mã xe")]
    public int Id { get; set; }
    
    [Display(Name = "Tên xe")]
    public string Name { get; set; }
    
    [Display(Name = "Biển số")]
    public string LicensePlate { get; set; }
    
    [Display(Name = "Màu sắc")]
    public string Color { get; set; }
    
    [Display(Name = "Số chỗ ngồi")]
    public int Seat { get; set; }
    
    [Display(Name = "Hộp số")]
    public TransmissionEnum TransmissionEnum { get; set; }
    
    [Display(Name = "Nhiên liệu")]
    public FuelEnum FuelEnum { get; set; }
    
    [Display(Name = "Hãng xe")]
    public string BrandName { get; set; }
    
    [Display(Name = "Loại xe")]
    public string CarTypeName { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Car, ListCarViewModel>();
        }
    }
}