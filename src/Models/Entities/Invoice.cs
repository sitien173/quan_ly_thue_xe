namespace CarRentalManagement.Models.Entities;

public class Invoice
{
    public int Id { get; set; }
    public int ContractId { get; set; }
    public string Content { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public decimal TotalPriceWithVat { get; set; }
    public int Vat { get; set; } = 10;
    public string Money { get; set; } = null!;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Contract Contract { get; set; } = null!;
}