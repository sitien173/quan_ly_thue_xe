using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.InvoiceManagement;

public class AddInvoiceViewModel
{
    public AddInvoiceViewModel()
    {
        InvoiceDetails = new List<InvoiceDetailViewModel>();
    }
    
    [Display(Name = "Mã hợp đồng")]
    [HiddenInput]
    public int ContractId { get; set; }
    
    [Display(Name = "Hình thức thanh toán")]
    public PayMethodEnum PayMethodEnum { get; set; }
    
    [Display(Name = "Tổng cộng")]
    [DataType(DataType.Text)]
    public decimal Total { get; set; }
    
    [Display(Name = "Còn lại")]
    [DataType(DataType.Text)]
    public decimal Debt { get; set; }
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Thanh toán")]
    [DataType(DataType.Text)]
    public decimal PayOff { get; set; }
    
    [Display(Name = "Nội dung thanh toán")]
    public string? Content { get; set; }
    
    [HiddenInput]
    public int CreatedBy { get; set; }
    
    public List<InvoiceDetailViewModel> InvoiceDetails { get; set; }
    
    public CustomerDetailViewModel CustomerDetail { get; set; }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
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
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Căn cước công dân")]
        public string IDCard { get; set; }
        
        [Display(Name = "Ngày cấp")]
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }
        
        [Display(Name = "Nơi cấp")]
        public string PlaceOfIssue { get; set; }
        
        [Display(Name = "Địa chỉ thường trú")]
        public string Domicile { get; set; }
        
        [Display(Name = "Địa chỉ hiện tại")]
        public string CurrentAddress { get; set; }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Customer, CustomerDetailViewModel>()
                .ForMember(x => x.FullName, opt => 
                    opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            
            CreateMap<AddInvoiceViewModel, Invoice>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.InvoiceDetails, opt => opt.MapFrom(x => x.InvoiceDetails))
                .AfterMap((src, dest) =>
                {
                    dest.TotalCarRental = src.InvoiceDetails.Count;
                    dest.Total = src.InvoiceDetails.Sum(x => x.Price);
                    dest.Debt = Math.Max(0, src.Total - src.Prepay - src.PayOff);
                });

            CreateMap<ContractDetail, InvoiceDetailViewModel>();
            CreateMap<InvoiceDetailViewModel, InvoiceDetail>();
        }
    }
}