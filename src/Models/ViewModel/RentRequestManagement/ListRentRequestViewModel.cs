using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.RentRequestManagement;

public class ListRentRequestViewModel
{
    [Display(Name = "Mã yêu cầu thuê")]
    public int Id { get; set; }
    
    [Display(Name = "Mã khách hàng")]
    public int CustomerId { get; set; }
    
    [Display(Name = "Mã xe")]
    public int CarId { get; set; }
    
    [Display(Name = "Ngày thuê")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    public DateTime RentalDate { get; set; }
    
    [Display(Name = "Ngày trả")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    public DateTime ReturnedDate { get; set; }
    
    [Display(Name = "Tình trạng")]
    public RentRequestStatusEnum RentRequestStatusEnum { get; set; }
    
    [Display(Name = "Phương thức thuê")]
    public RentalMethodEnum RentalMethod { get; set; }
    
    [Display(Name = "Tổng cộng")]
    [DataType(DataType.Text)]
    public decimal TotalPrice { get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<RentRequest, ListRentRequestViewModel>();
        }
    }
}