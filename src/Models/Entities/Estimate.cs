
namespace CarRentalManagement.Models.Entities;

public class Estimate
{
    public int Id { get; set; }
    public int CarTypeId { get; set; }
    public RentalMethodEnum RentalMethod { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public CarType CarType { get; set; }
}