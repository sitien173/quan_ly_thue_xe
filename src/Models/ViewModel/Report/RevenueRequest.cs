namespace CarRentalManagement.Models.ViewModel.Report;

public class RevenueRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ReportTypeEnum ReportType { get; set; }
}