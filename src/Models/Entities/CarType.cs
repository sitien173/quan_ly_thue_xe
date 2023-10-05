namespace CarRentalManagement.Models.Entities;

public class CarType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Icon { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Car> Cars { get; set; } = new List<Car>();
    public ICollection<Estimate> Estimates { get; set; } = new List<Estimate>();
    public ICollection<SurCharge> Surcharges { get; set; } = new List<SurCharge>();
}