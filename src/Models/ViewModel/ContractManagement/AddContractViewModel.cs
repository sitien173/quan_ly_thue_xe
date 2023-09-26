using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalManagement.Models.ViewModel.ContractManagement;

public class AddContractViewModel
{
    public AddContractViewModel()
    {
        ContractDetails = new List<ContractDetailViewModel>();
        CustomerSelectListItems = new List<SelectListItem>();
        CarSelectListItems = new List<SelectListItem>();
    }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Khách hàng")]
    [Required(ErrorMessage = "Khách hàng không được để trống")]
    public int CustomerId { get; set; }
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Tổng số xe thuê")]
    [Required(ErrorMessage = "Tổng số xe thuê không được để trống")]
    public int TotalCarRent { get; set; } = 1;
    
    [HiddenInput]
    public int CreatedBy{ get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note{ get; set; }
    
    [Display(Name = "Chi tiết hợp đồng")]
    public List<ContractDetailViewModel> ContractDetails { get; set; }

    [HiddenInput]
    public List<SelectListItem> CustomerSelectListItems { get; set; }
    
    public List<SelectListItem> CarSelectListItems { get; set; }
    
    public sealed class ContractDetailViewModel
    {
        [Display(Name = "Xe")]
        public int CarId { get; set; }
        
        [Display(Name = "Ngày thuê")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalDate { get; set; }
        
        [Display(Name = "Ngày trả")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReturnedDate { get; set; }
        
        [Display(Name = "Phương thức thuê")]
        public RentalMethodEnum RentalMethod { get; set; }

        [Display(Name = "Số lượng")] 
        public int Amount { get; set; } = 1;
        
        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [DataType(DataType.Text)]
        public decimal UnitPrice { get; set; }
        
        [Display(Name = "Thành tiền")]
        [DataType(DataType.Text)]
        public decimal Price { get; set; }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddContractViewModel, Contract>()
                .AfterMap((src, dest) =>
                {
                    dest.TotalCarRent = src.ContractDetails.Count;
                    dest.Total = src.ContractDetails.Sum(x => x.Price);
                    dest.Debt = Math.Max(0, dest.Total - dest.Prepay);
                });
            CreateMap<ContractDetailViewModel, ContractDetail>();
        }
    }
}