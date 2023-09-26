namespace CarRentalManagement.Models.Entities;

public class Damages
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int ContractId { get; set; }
    public decimal RepairCost { get; set; }
    public DateTime? DamagedAt { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    
    public Car Car { get; set; }
    public Contract Contract { get; set; }
}