namespace CarRentalManagement.Models.Settings;
public class CompanySettings
{
    public const string Section = nameof(CompanySettings);
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string TaxCode { get; set; } = null!;
    public string Representative { get; set; } = null!;
    public string RepresentativePosition { get; set; } = null!;
    public string Website { get; set; } = null!;
}