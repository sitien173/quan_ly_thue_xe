using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Extensions;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.ContractManagement;

public class ListContractViewModel
{
    [Display(Name = "Mã hợp đồng")]
    public int Id { get; set; }
    
    [Display(Name = "Tổng tiền")]
    [DataType(DataType.Text)]
    public decimal Total { get; set; }
    
    [Display(Name = "Cọc")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt{ get; set; }
    
    [Display(Name = "Mã đặt xe")]
    public int RentRequestId { get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note{ get; set; }
    
    [Display(Name = "Trạng thái")]
    public ContractStatusEnum Status { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Contract, ListContractViewModel>();
        }
    }
}