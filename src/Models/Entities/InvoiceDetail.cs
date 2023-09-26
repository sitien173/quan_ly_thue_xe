namespace CarRentalManagement.Models.Entities;

public class InvoiceDetail
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int CarId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Price { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnedDate { get; set; }
    public int Amount { get; set; }
    public RentalMethodEnum RentalMethod { get; set; }
    public string? Note { get; set; }
    public Invoice Invoice { get; set; }
    public Car Car { get; set; }
}