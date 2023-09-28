using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.ReceiptManagement;

public class PreviewReceiptViewModel
{
    [Display(Name = "Mã phiếu")]
    public int Id { get; set; }
    
    [Display(Name = "Loại phiếu")]
    public ReceiptTypeEnum Type { get; set; }
    
    [Display(Name = "Họ tên người nộp/ nhận tiền")]
    public string FullName { get; set; } = null!;
    
    [Display(Name = "Địa chỉ")]
    public string Address { get; set; } = null!;
    
    [Display(Name = "Nội dung")]
    public string Content { get; set; } = null!;
    
    [Display(Name = "Số tiền")]
    [DataType(DataType.Text)]
    public decimal Price { get; set; }
    
    [Display(Name = "Số tiền bằng chữ")]
    public string Money { get; set; } = null!;
    
    [Display(Name = "Ngày tạo")]
    public DateTime CreatedAt { get; set; }
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Receipt, PreviewReceiptViewModel>();
        }
    }
}