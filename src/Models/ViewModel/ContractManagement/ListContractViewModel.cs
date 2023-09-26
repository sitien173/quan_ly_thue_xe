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
    
    [Display(Name = "Đưa trước")]
    [DataType(DataType.Text)]
    public decimal Prepay { get; set; }
    
    [Display(Name = "Đã thanh toán")]
    [DataType(DataType.Text)]
    public decimal PayOff { get; set; }
    
    private decimal debt => Total - PayOff;
    
    [Display(Name = "Còn lại")]
    [DataType(DataType.Text)]
    public decimal Debt => debt < 0 ? 0 : debt;

    [Display(Name = "Số lượng xe thuê")]
    public int TotalCarRent { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt{ get; set; }
    
    [Display(Name = "Khách hàng")]
    public int CustomerId{ get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note{ get; set; }
    
    public bool IsTerminationMinutes { set; get; }
    
    [Display(Name = "Tình trạng")]
    public string Status => IsTerminationMinutes ? ContractStatusEnum.Finished.GetDescription() : ContractStatusEnum.NotFinished.GetDescription();

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Contract, ListContractViewModel>()
                .ForMember(x => x.PayOff, opt =>
                    opt.MapFrom(x => x.Prepay + x.Invoices.Sum(i => i.PayOff)));
        }
    }
}