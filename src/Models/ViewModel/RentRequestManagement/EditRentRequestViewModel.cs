using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.RentRequestManagement;

public class EditRentRequestViewModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Display(Name = "Ngày thuê")]
    [DataType(DataType.Date)]
    public DateTime RentalDate { get; set; }
    
    [Display(Name = "Mã khách hàng")]
    public int CustomerId { get; set; }
    
    [Display(Name = "Mã xe")]
    public int CarId { get; set; }
    
    [Display(Name = "Ngày trả")]
    [DataType(DataType.Date)]
    public DateTime ReturnedDate { get; set; }
    
    [Display(Name = "Trạng thái thuê")]
    public RentRequestStatusEnum RentRequestStatusEnum { get; set; }
    
    [Display(Name = "Phương thức thuê")]
    [HiddenInput]
    public RentalMethodEnum RentalMethod { get; set; }

    [Display(Name = "Tổng tiền")]
    [DataType(DataType.Text)]
    public decimal TotalPrice { get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }

    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Ignore]
    public CarDetailViewModel CarDetail { get; set; }
    
    [Ignore]
    public CustomerDetailViewModel CustomerDetail { get; set; }

    public sealed class CarDetailViewModel
    {
        public CarDetailViewModel()
        {
            CarGalleries = new List<CarGalleryViewModel>();
            CarFeatures = new List<string>();
            EstimatesList = new List<EstimatesViewModel>();
            SurChargeList = new List<SurChargeViewModel>();
        }
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string LicensePlate { get; set; }
    
        public string? OverallSize { get; set; }
    
        public string? LongStandard { get; set; }
    
        public string? Engine { get; set; }
    
        public string? CapacityTank { get; set; }
    
        public string? FuelConsumption{ get; set; }
    
        public string Color { get; set; }
    
        public TransmissionEnum TransmissionEnum { get; set; }
    
        public FuelEnum FuelEnum { get; set; }
    
        public string? Description { get; set; }
    
        public int Seat { get; set; }
    
        public int ManufactureYear { get; set; }
    
        public string BrandName { get; set; }
    
        public string CarTypeName { get; set; }
    
        public List<CarGalleryViewModel> CarGalleries { get; set; }
    
        public List<string> CarFeatures { get; set; }
    
        public List<EstimatesViewModel> EstimatesList { get; set; }
        public List<SurChargeViewModel> SurChargeList { get; set; }
    
        public sealed class EstimatesViewModel
        {
            public RentalMethodEnum RentalMethod { get; set; }
            public string UnitPrice { get; set; }
        }
        
        public sealed class SurChargeViewModel
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }
    
        public sealed class CarGalleryViewModel
        {
            public string Url { get; set; }
            public string ThumbUrl { get; set; }
        }
    }
    public sealed class CustomerDetailViewModel
    {
        public CustomerDetailViewModel()
        {
            Licenses = Enumerable.Empty<LicenseViewModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Domicile { get; set; }
        public string TempAccommodation { get; set; }
        public string CurrentAddress { get; set; }
        public string Profession { get; set; }
        public string WorkPlace { get; set; }
        public string Avatar { get; set; }
        public string AvatarThumb { get; set; }
        public SexEnum SexEnum { get; set; }
        public string IDCard { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string FrontalPhoto { get; set; }
        public string FrontalPhotoThumb { get; set; }
        public string RearPhoto { get; set; }
        public string RearPhotoThumb { get; set; }
        public IEnumerable<LicenseViewModel> Licenses { get; set; }

        public sealed class LicenseViewModel
        {
            public string Number { get; set; }
            public string Grade { get; set; }
            public DateTime DateOfIssue { get; set; }
            public string PlaceOfIssue { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string FrontalPhoto { get; set; }
            public string FrontalPhotoThumb { get; set; }
            public string RearPhoto { get; set; }
            public string RearPhotoThumb { get; set; }
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarPhotoGallery, CarDetailViewModel.CarGalleryViewModel>();
            CreateMap<Estimate, CarDetailViewModel.EstimatesViewModel>();
            CreateMap<SurCharge, CarDetailViewModel.SurChargeViewModel>();
            CreateMap<Entities.Car, CarDetailViewModel>()
                .ForMember(x => x.CarFeatures, opt =>
                    opt.MapFrom(x => x.CarFeatures.Select(xx => xx.Feature.Name).ToArray()))
                .ForMember(x => x.EstimatesList, opt =>
                    opt.MapFrom(x => x.CarType.Estimates))
                .ForMember(x => x.CarGalleries, opt =>
                    opt.MapFrom(x => x.CarPhotoGalleries))
                .ForMember(x => x.SurChargeList, opt =>
                    opt.MapFrom(x => x.CarType.Surcharges));
            
            CreateMap<License, CustomerDetailViewModel.LicenseViewModel>();
            CreateMap<Entities.Customer, CustomerDetailViewModel>()
                .ForMember(x => x.Licenses, opt =>
                    opt.MapAtRuntime());

            CreateMap<RentRequest, EditRentRequestViewModel>()
                .ForMember(x => x.CustomerDetail, opt =>
                    opt.MapFrom(x => x.Customer))
                .ForMember(x => x.CarDetail, opt =>
                    opt.MapFrom(x => x.Car))
                .ReverseMap();
        }
    }
}