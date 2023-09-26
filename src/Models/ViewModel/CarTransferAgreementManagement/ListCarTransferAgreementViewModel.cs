using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.CarTransferAgreementManagement;

public class ListCarTransferAgreementViewModel
{
    [Display(Name = "Mã")]
    public int Id { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Mã xe")]
    public int CarId { get; set; }
    
    [Display(Name = "Ngày tạo")]
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }
    
    public CheckInOutEnum CheckInOutEnum { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarTransferAgreement, ListCarTransferAgreementViewModel>();
        }
    }
}