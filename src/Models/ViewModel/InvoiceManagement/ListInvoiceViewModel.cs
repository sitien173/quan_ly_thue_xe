using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.InvoiceManagement;

public class ListInvoiceViewModel
{
    [Display(Name = "Mã hóa đơn")]
    public int Id { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Phương thức thanh toán")]
    public PayMethodEnum PayMethodEnum { get; set; }
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Còn lại")]
    [DataType(DataType.Text)]
    public decimal Debt { get; set; }
    
    [Display(Name = "Khách thanh toán")]
    [DataType(DataType.Text)]
    public decimal PayOff { get; set; }
    
    [Display(Name = "Tông tiền")]
    [DataType(DataType.Text)]
    public decimal Total { get; set; }
    
    [Display(Name = "Tổng số xe thuê")]
    public int TotalCarRental { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  

    public DateTime CreatedAt { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Invoice, ListInvoiceViewModel>();
        }
    }
}