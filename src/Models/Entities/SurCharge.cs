namespace CarRentalManagement.Models.Entities;

public class SurCharge
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public int CarTypeId { get; set; }
    public CarType CarType { get; set; }
}