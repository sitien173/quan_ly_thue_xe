namespace CarRentalManagement.Models.Entities;

public class CarType
{
    public CarType()
    {
        Cars = new List<Car>();
        Estimates = new List<Estimate>();
        Surcharges = new List<SurCharge>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Car> Cars { get; set; }
    public ICollection<Estimate> Estimates { get; set; }
    public ICollection<SurCharge> Surcharges { get; set; }
}