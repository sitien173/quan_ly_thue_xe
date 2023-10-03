namespace CarRentalManagement.Models.Entities;

public class Contract
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public decimal Prepay { get; set; }
    public bool IsDeleted{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public int CreatedBy{ get; set; }
    public string? Note{ get; set; }
    public ContractStatusEnum Status { get; set; }
    public ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<CarTransferAgreement> CarTransferAgreements { get; set; } = new List<CarTransferAgreement>();
    public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
    public ICollection<IncidentReports> IncidentReports { get; set; } = new List<IncidentReports>();
    public Damages? Damages { get; set; }
    public int RentRequestId { get; set; }
    public RentRequest RentRequest { get; set; }
}