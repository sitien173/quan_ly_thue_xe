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
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }
    
    [Display(Name = "Sub total")]
    [DataType(DataType.Text)]
    public decimal UnitPrice { get; set; }
    
    [Display(Name = "Total payment")]
    [DataType(DataType.Text)]
    public decimal TotalPriceWithVat { get; set; }
    
    [Display(Name = "VAT amount")]
    public int Vat { get; set; } = 10;
    
    [Display(Name = "Amount in words")]
    public string Money { get; set; } = null!;
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Invoice, ListInvoiceViewModel>();
        }
    }
}