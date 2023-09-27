using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.DamagesManagement;

public class ListDamagesViewModel
{
    [Display(Name = "Mã sửa chữa")]
    public int Id { get; set; }
    
    [Display(Name = "Mã xe")]
    public int CarId { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Chi phí sửa chữa")]
    [DataType(DataType.Text)]
    public decimal TotalRepairCost { get; set; }
    
    [Display(Name = "Ngày hư hỏng")]
    public DateTime? DamagedAt { get; set; }
    
    [Display(Name = "Ngày tạo")]
    public DateTime CreatedAt { get; set; }
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Damages, ListDamagesViewModel>();
        }
    }
}