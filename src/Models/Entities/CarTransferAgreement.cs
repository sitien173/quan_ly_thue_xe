namespace CarRentalManagement.Models.Entities;

public class CarTransferAgreement
{
    public int Id { get; set; }
    public int ContractId { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public Contract Contract { get; set; } = null!;
    public string? TestListDetail { get; set; }
    public string? EquipmentAttend { get; set; }
    public string? VehicleProfileSetAttend { get; set; }
    public CheckInOutEnum CheckInOutEnum { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    
}