using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.DamagesManagement;

public class PreviewDamagesViewModel
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int ContractId { get; set; }
    public decimal TotalRepairCost { get; set; }
    public DateTime DamagedAt { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public string CreatedByFullName { get; set; }
    
    public CustomerDetailViewModel CustomerDetail { get; set; }
    public CarDetailViewModel CarDetail { get; set; }
    
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
    
    public class CarDetailViewModel
    {
        public string Name { get; set; }
        public string CarTypeName { get; set; }
        public string LicensePlate { get; set; }
        public string EngineSerialNumber { get; set; }
        public string VIN { get; set; }
        public string BrandName { get; set; }
    }
    
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Customer, CustomerDetailViewModel>()
                .ForMember(x => x.FullName, opt => 
                    opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));

            CreateMap<Entities.Car, CarDetailViewModel>();
            
            CreateMap<Damages, PreviewDamagesViewModel>()
                .ForMember(x => x.CustomerDetail, opt => opt.MapFrom(x => x.Contract.RentRequest.Customer))
                .ForMember(x => x.CarDetail, opt => opt.MapFrom(x => x.Car));
        }
    }
}