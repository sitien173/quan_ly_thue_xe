namespace CarRentalManagement.Models.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateTime? ReleaseAt { get; set; }
    public string Country { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}