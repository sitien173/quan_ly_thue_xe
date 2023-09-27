using AutoMapper;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.RentRequestManagement;

namespace CarRentalManagement.Models.ViewModel.ContractManagement;

public class PreviewContractViewModel
{
    public PreviewContractViewModel()
    {
        ContractDetails = new List<ContractDetailViewModel>();
    }
    public int Id { get; set; }
    public int TotalCarRent { get; set; }
    public string Total { get; set; }
    public string Prepay { get; set; }
    public string Debt { get; set; }
    public string CreatedAt { get; set; }
    public CustomerDetailViewModel CustomerDetail { get; set; }
    public List<ContractDetailViewModel> ContractDetails { get; set; }
    
    public class CustomerDetailViewModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IDCard { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Domicile { get; set; }
        public string TempAccommodation { get; set; }
    }

    public class ContractDetailViewModel
    {
        public CarDetailViewModel CarDetail { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public EstimateViewModel Estimate { get; set; }
        public List<SurchargeViewModel> SurCharges { get; set; }

        public class CarDetailViewModel
        {
            public string Name { get; set; }
            public string CarTypeName { get; set; }
            public string LicensePlate { get; set; }
            public string EngineSerialNumber { get; set; }
            public string VIN { get; set; }
            public string BrandName { get; set; }
        }
        
        public class EstimateViewModel
        {
            public RentalMethodEnum RentalMethod { get; set; }
            public string UnitPrice { get; set; }
        }
        
        public class SurchargeViewModel
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Car, ContractDetailViewModel.CarDetailViewModel>();
            CreateMap<SurCharge, ContractDetailViewModel.SurchargeViewModel>();
            CreateMap<Estimate, ContractDetailViewModel.EstimateViewModel>();

            CreateMap<Entities.Customer, CustomerDetailViewModel>()
                .ForMember(x => x.FullName, opt => 
                    opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            
            CreateMap<ContractDetail, ContractDetailViewModel>()
                .ForMember(x => x.Estimate, opt =>
                    opt.MapFrom(x => x.Car.CarType.Estimates.First()))
                .ForMember(x => x.SurCharges, opt =>
                    opt.MapFrom(x => x.Car.CarType.Surcharges))
                .ForMember(x => x.CarDetail, opt => 
                    opt.MapFrom(x => x.Car));
            
            CreateMap<Contract, PreviewContractViewModel>()
                .ForMember(x => x.CustomerDetail, opt => 
                    opt.MapFrom(x => x.RentRequest.Customer))
                .ForMember(x => x.ContractDetails, opt => 
                    opt.MapFrom(x => x.ContractDetails));

        }
    }
}