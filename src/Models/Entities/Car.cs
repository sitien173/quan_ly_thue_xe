namespace CarRentalManagement.Models.Entities;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LicensePlate { get; set; } = null!;
    public string VIN { get; set; } = null!;
    public string EngineSerialNumber { get; set; } = null!;
    public string? OverallSize { get; set; }
    public string? LongStandard { get; set; }
    public string? Engine { get; set; }
    public string? CapacityTank { get; set; }
    public string? FuelConsumption{ get; set; }
    public string Color { get; set; } = null!;
    public TransmissionEnum TransmissionEnum { get; set; }
    public FuelEnum FuelEnum { get; set; }
    public string? Description { get; set; }
    public int Seat { get; set; }
    public int ManufactureYear { get; set; }
    public int BrandId { get; set; }
    public int CarTypeId { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsRepairing { get; set; }
    public Brand Brand { get; set; } = null!;
    public CarType CarType { get; set; } = null!;
    public ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
    public ICollection<CarPhotoGallery> CarPhotoGalleries { get; set; } = new List<CarPhotoGallery>();
    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    public ICollection<Follow> Follows { get; set; } = new List<Follow>();
    public ICollection<RentRequest> RentRequests { get; set; } = new List<RentRequest>();
    public ICollection<CarTransferAgreement> CarTransferAgreements { get; set; } = new List<CarTransferAgreement>();
    public ICollection<Damages> Damages { get; set; } = new List<Damages>();
}