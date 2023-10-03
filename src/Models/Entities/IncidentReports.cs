namespace CarRentalManagement.Models.Entities;

public class IncidentReports
{
    public int Id { get; set; }
    public int ContractId { get; set; }
    public string Description { get; set; }
    public string? AdditionalDetails  { get; set; }
    public IncidentReportsTypeEnum ReportType { get; set; }
    public DateTime ReportDate { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Contract Contract { get;set; }
}