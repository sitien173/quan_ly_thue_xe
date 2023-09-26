namespace CarRentalManagement.Models.Settings;

public class CustomSettings
{
    public const string Section = nameof(CustomSettings);
    public string UploadPath { get; set; } = null!;
    public string UploadThumbPath { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
}