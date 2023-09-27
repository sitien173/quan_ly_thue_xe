using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.ContractManagement;

public class AddContractViewModel
{
    public AddContractViewModel()
    {
        ContractDetails = new List<ContractDetailViewModel>();
    }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Mã đặt xe")]
    [Required(ErrorMessage = "Mã đặt xe không được để trống")]
    public int RentRequestId { get; set; }
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [HiddenInput]
    public int CreatedBy{ get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note{ get; set; }
    
    [Display(Name = "Chi tiết hợp đồng")]
    public List<ContractDetailViewModel> ContractDetails { get; set; }
    
    public sealed class ContractDetailViewModel
    {
        [Display(Name = "Xe")]
        public int CarId { get; set; }
        
        [Display(Name = "Ngày thuê")]
        public DateTime RentalDate { get; set; }
        
        [Display(Name = "Ngày trả")]
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
                    dest.Total = src.ContractDetails.Sum(x => x.Price);
                });
            CreateMap<ContractDetailViewModel, ContractDetail>();
        }
    }
}