namespace CarRentalManagement.Models.Entities;

public class Damages
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int ContractId { get; set; }
    public decimal TotalRepairCost { get; set; }
    public DateTime DamagedAt { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    
    public Car Car { get; set; }
    public Contract Contract { get; set; }
}