namespace CarRentalManagement.Models.Entities;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
}