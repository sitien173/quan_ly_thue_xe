namespace CarRentalManagement.Models.Entities;

public class Feature
{
    public Feature()
    {
        CarFeatures = new List<CarFeature>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<CarFeature> CarFeatures { get; set; }
}