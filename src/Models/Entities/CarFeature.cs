namespace CarRentalManagement.Models.Entities;

public class CarFeature
{
    public int CarId { get; set; }
    public int FeatureId { get; set; }
    public Car Car { get; set; } = null!;
    public Feature Feature { get; set; } = null!;
}