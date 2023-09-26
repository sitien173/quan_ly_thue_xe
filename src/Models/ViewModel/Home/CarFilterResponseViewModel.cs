using AutoMapper;

namespace CarRentalManagement.Models.ViewModel.Home;

public class CarFilterResponseViewModel
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

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Car, CarFilterResponseViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.CarPhotoGalleries.First().ThumbUrl));

        }
    }
}