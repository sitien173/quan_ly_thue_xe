using AutoMapper;

namespace CarRentalManagement.Models.ViewModel.Car;

public class CarDetailViewModel
{
    public CarDetailViewModel()
    {
        CarPhotoGalleries = new List<CarGalleryViewModel>();
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
    
    public List<CarGalleryViewModel> CarPhotoGalleries { get; set; }
    
    public List<string> CarFeatures { get; set; }
    
    public List<EstimatesViewModel> EstimatesList { get; set; }
    public List<SurChargeViewModel> SurChargeList { get; set; }
    
    public sealed class EstimatesViewModel
    {
        public int Id { get; set; }
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
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.CarPhotoGallery, CarGalleryViewModel>();
            CreateMap<Entities.SurCharge, SurChargeViewModel>();
            CreateMap<Entities.Estimate, EstimatesViewModel>();
            CreateMap<Entities.Car, CarDetailViewModel>()
                .ForMember(x => x.CarPhotoGalleries, opt =>
                    opt.MapAtRuntime())
                .ForMember(x => x.EstimatesList, opt =>
                    opt.MapFrom(x => x.CarType.Estimates))
                .ForMember(x => x.SurChargeList, opt =>
                    opt.MapFrom(x => x.CarType.Surcharges))
                .ForMember(x => x.CarFeatures, opt =>
                    opt.MapFrom(x => x.CarFeatures.Select(xx => xx.Feature.Name).ToList())
                );
        }
    }
}