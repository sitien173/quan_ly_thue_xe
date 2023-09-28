using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.ReceiptManagement;

public class AddReceiptViewModel
{
    [Required(ErrorMessage = "Loại phiếu không được để trống")]
    [Display(Name = "Loại phiếu")]
    public ReceiptTypeEnum Type { get; set; }
    
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [Display(Name = "Họ tên người nộp/ nhận tiền")]
    public string FullName { get; set; } = null!;
    
    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    [Display(Name = "Địa chỉ")]
    public string Address { get; set; } = null!;
    
    [Required(ErrorMessage = "Nội dung không được để trống")]
    [Display(Name = "Nội dung")]
    public string Content { get; set; } = null!;
    
    [Required(ErrorMessage = "Số tiền không được để trống")]
    [Display(Name = "Số tiền")]
    [DataType(DataType.Text)]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Số tiền bằng chữ không được để trống")]
    [Display(Name = "Số tiền bằng chữ")]
    public string Money { get; set; } = null!;
    
    [HiddenInput]
    public DateTime CreatedAt { get; set; }
    
    [HiddenInput]
    public int CreatedBy { get; set; }
    
    [HiddenInput]
    [Display(Name = "Mã hợp đồng")]
    [Required(ErrorMessage = "Mã hợp đồng không được để trống")]
    public int ContractId { get; set; }

    [HiddenInput]
    public string? ReturnUrl { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddReceiptViewModel, Receipt>();
        }
    }
}