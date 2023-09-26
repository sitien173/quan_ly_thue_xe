namespace CarRentalManagement.Models.Entities;

public class Accident
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int ContractId { get; set; }
    public DateTime? AccidentAt { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    
    public Car Car { get; set; }
    public Contract Contract { get; set; }
}