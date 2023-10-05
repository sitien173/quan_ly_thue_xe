namespace CarRentalManagement.Models.Entities;

public class Follow
{
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Car Car { get; set; } = null!;
}