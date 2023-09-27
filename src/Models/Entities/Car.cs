namespace CarRentalManagement.Models.Entities;

public class Car
{
    public Car()
    {
        ContractDetails = new List<ContractDetail>();
        CarPhotoGalleries = new List<CarPhotoGallery>();
        CarFeatures = new List<CarFeature>();
        Follows = new List<Follow>();
        RentRequests = new List<RentRequest>();
        CarTransferAgreements = new List<CarTransferAgreement>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string LicensePlate { get; set; }
    public string VIN { get; set; }
    public string EngineSerialNumber { get; set; }
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
    public int BrandId { get; set; }
    public int CarTypeId { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsRepairing { get; set; }
    public Brand Brand { get; set; }
    public CarType CarType { get; set; }
    public ICollection<ContractDetail> ContractDetails { get; set; }
    public ICollection<CarPhotoGallery> CarPhotoGalleries { get; set; }
    public ICollection<CarFeature> CarFeatures { get; set; }
    public ICollection<Follow> Follows { get; set; }
    public ICollection<RentRequest> RentRequests { get; set; }
    public ICollection<CarTransferAgreement> CarTransferAgreements { get; set; }
    public ICollection<Damages> Damages { get; set; }
}