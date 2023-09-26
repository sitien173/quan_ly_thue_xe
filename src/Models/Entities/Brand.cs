namespace CarRentalManagement.Models.Entities;

public class Brand
{
    public Brand()
    {
        Cars = new List<Car>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime? ReleaseAt { get; set; }
    public string Country { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Car> Cars { get; set; }
}