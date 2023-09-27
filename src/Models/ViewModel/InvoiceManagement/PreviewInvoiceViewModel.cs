using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.InvoiceManagement;

public class PreviewInvoiceViewModel
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
    public decimal UnitPrice { get; set; }
    
    [Display(Name = "Total payment")]
    public decimal TotalPriceWithVat { get; set; }
    
    [Display(Name = "VAT amount")]
    public int Vat { get; set; } = 10;
    
    [Display(Name = "Amount in words")]
    public string Money { get; set; } = null!;
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }
    
    [Display(Name = "Nội dung thanh toán")]
    [Required(ErrorMessage = "Nội dung thanh toán không được để trống")]
    public string Content { get; set; }
    
    public CustomerDetailViewModel CustomerDetail { get; set; }
    
    public class CustomerDetailViewModel
    {
        [Display(Name = "Tên khách hàng")]
        public string FullName { get; set; }
        
        [Display(Name = "Giới tính")]
        public SexEnum SexEnum { get; set; }
        
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Căn cước công dân")]
        public string IDCard { get; set; }
        
        [Display(Name = "Ngày cấp")]
        [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfIssue { get; set; }
        
        [Display(Name = "Nơi cấp")]
        public string PlaceOfIssue { get; set; }
        
        [Display(Name = "Địa chỉ thường trú")]
        public string Domicile { get; set; }
        
        [Display(Name = "Địa chỉ hiện tại")]
        public string CurrentAddress { get; set; }
        
        public string TempAccommodation { get; set; }
    }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Customer, CustomerDetailViewModel>()
                .ForMember(x => x.FullName, opt => 
                    opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            
            
            CreateMap<Invoice, PreviewInvoiceViewModel>()
                .ForMember(x => x.CustomerDetail, opt => opt.MapFrom(x => x.Contract.RentRequest.Customer));
            
        }
    }
}