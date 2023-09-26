namespace CarRentalManagement.Models.Entities;

public class Invoice
{
    public Invoice()
    {
        InvoiceDetails = new List<InvoiceDetail>();
    }
    public int Id { get; set; }
    public int ContractId { get; set; }
    public PayMethodEnum PayMethodEnum { get; set; }
    public decimal Prepay { get; set; }
    public decimal Debt { get; set; }
    public decimal PayOff { get; set; }
    public decimal Total { get; set; }
    public string? Content { get; set; }
    public int TotalCarRental { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Contract Contract { get; set; }
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}