namespace CarRentalManagement.Models.Entities;

public class Contract
{
    public Contract()
    {
        ContractDetails = new List<ContractDetail>();
        Invoices = new List<Invoice>();
        CarTransferAgreements = new List<CarTransferAgreement>();
    }
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Total { get; set; }
    public decimal Prepay { get; set; }
    public decimal Debt { get; set; }
    public int TotalCarRent { get; set; }
    public bool IsDeleted{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public int CreatedBy{ get; set; }
    public string? Note{ get; set; }
    public bool IsTerminationMinutes{ get; set; }
    public Customer Customer { get; set; }
    public ICollection<ContractDetail> ContractDetails { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<CarTransferAgreement> CarTransferAgreements { get; set; }
    public Accident? Accidents { get; set; }
    public Damages? Damages { get; set; }
}