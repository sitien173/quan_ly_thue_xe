namespace CarRentalManagement.Models.Entities;

public class Receipt
{
    public int Id { get; set; }
    public ReceiptTypeEnum Type { get; set; }
    public string FullName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string Money { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int ContractId { get; set; }
    public bool IsDeleted { get; set; }
    public Contract Contract { get; set; } = null!;
}