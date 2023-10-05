namespace CarRentalManagement.Models.Entities;

public class ContractDetail
{
    public int Id { get; set; }
    public int ContractId { get; set; }
    public int CarId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnedDate { get; set; }
    public RentalMethodEnum RentalMethod { get; set; }
    public int Amount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Price { get; set; }
    public Contract Contract { get; set; } = null!;
    public Car Car { get; set; } = null!;
}