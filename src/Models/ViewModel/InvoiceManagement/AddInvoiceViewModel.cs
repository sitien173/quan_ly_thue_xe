using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.InvoiceManagement;

public class AddInvoiceViewModel
{
    [HiddenInput]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã hợp đồng không được để trống")]
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nội dung không được để trống")]
    [Display(Name = "Nội dung")]
    public string Content { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Sub total không được để trống")]
    [Display(Name = "Cộng tiền hàng (Sub total)")]
    [DataType(DataType.Text)]
    public decimal UnitPrice { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Total payment không được để trống")]
    [Display(Name = "Tổng cộng tiền thanh toán (Total payment)")]
    [DataType(DataType.Text)]
    public decimal TotalPriceWithVat { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Thuế không được để trống")]
    [Display(Name = "Tiền thuế GTGT (VAT amount)")]
    public int Vat { get; set; } = 10;
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Số tiền bằng chữ không được để trống")]
    [Display(Name = "Số tiền viết bằng chữ (Amount in words)")]
    public string Money { get; set; } = null!;
    
    [HiddenInput]
    public int CreatedBy { get; set; }
    
    [HiddenInput]
    public DateTime CreatedAt { get; set; }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddInvoiceViewModel, Invoice>();
        }
    }
}