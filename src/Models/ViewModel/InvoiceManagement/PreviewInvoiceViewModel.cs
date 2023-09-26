using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.InvoiceManagement;

public class PreviewInvoiceViewModel
{
    public PreviewInvoiceViewModel()
    {
        InvoiceDetails = new List<InvoiceDetailViewModel>();
    }
    [Display(Name = "Mã hóa đơn")]
    public int Id { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    public int TotalCarRental { get; set; }
    
    [Display(Name = "Hình thức thanh toán")]
    public PayMethodEnum PayMethodEnum { get; set; }
    
    [Display(Name = "Tổng cộng")]
    [DataType(DataType.Text)]
    public decimal Total { get; set; }
    
    [Display(Name = "Còn lại")]
    [DataType(DataType.Text)]
    public decimal Debt { get; set; }
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Thanh toán")]
    [DataType(DataType.Text)]
    public decimal PayOff { get; set; }
    
    [Display(Name = "Nội dung thanh toán")]
    [Required(ErrorMessage = "Nội dung thanh toán không được để trống")]
    public string Content { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }

    public List<InvoiceDetailViewModel> InvoiceDetails { get; set; }
    
    public CustomerDetailViewModel CustomerDetail { get; set; }

    public class InvoiceDetailViewModel
    {
        [Display(Name = "Mã xe")]
        [HiddenInput]
        public int CarId { get; set; }
        
        [Display(Name = "Đơn giá")]
        [DataType(DataType.Text)]
        [HiddenInput]
        public decimal UnitPrice { get; set; }
        
        [Display(Name = "Thành tiền")]
        [DataType(DataType.Text)]
        [HiddenInput]
        public decimal Price { get; set; }
        
        [Display(Name = "Ngày thuê")]
        [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        [HiddenInput]
        public DateTime RentalDate { get; set; }
        
        [Display(Name = "Ngày trả")]
        [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        [HiddenInput]
        public DateTime ReturnedDate { get; set; }
        
        [Display(Name = "Số lượng")]
        [HiddenInput]
        public int Amount { get; set; }
        
        [HiddenInput]
        [Display(Name = "Hình thức thuê")]
        public RentalMethodEnum RentalMethod { get; set; }
    }
    
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
            
            CreateMap<InvoiceDetail, InvoiceDetailViewModel>();
            
            CreateMap<Invoice, PreviewInvoiceViewModel>()
                .ForMember(x => x.InvoiceDetails, opt => opt.MapFrom(x => x.InvoiceDetails))
                .ForMember(x => x.CustomerDetail, opt => opt.MapFrom(x => x.Contract.Customer));
            
        }
    }
}