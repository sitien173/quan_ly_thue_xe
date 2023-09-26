using AutoMapper;

namespace CarRentalManagement.Models.ViewModel.Customer;

public class CarFollowViewModel
{
    public CarFollowViewModel()
    {
        CarDetailViewModels = new List<CarDetailViewModel>();
    }
    
    public List<CarDetailViewModel> CarDetailViewModels { get; set; }
    public class CarDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string BrandCode { get; set; }
        public string CarTypeName { get; set; }
        public string ImageUrl { get; set; }
        public int Seat { get; set; }
        public FuelEnum FuelEnum { get; set; }
        public TransmissionEnum TransmissionEnum { get; set; }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Car, CarDetailViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.CarPhotoGalleries.First().ThumbUrl));

            CreateMap<Entities.Customer, CarFollowViewModel>()
                .ForMember(x => x.CarDetailViewModels, opt =>
                    opt.MapFrom(x => x.Follows.Select(xx => xx.Car)));

        }
    }
}