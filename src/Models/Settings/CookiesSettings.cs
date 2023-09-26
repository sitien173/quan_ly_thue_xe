namespace CarRentalManagement.Models.Settings;

public class CookiesSettings
{
    public const string Section = nameof(CookiesSettings);
    public string AuthenticationScheme { get; set; } = null!;
    public string CookiePrefix { get; set; } = null!;
    public string LoginPath { get; set; } = null!;
    public string LogoutPath { get; set; } = null!;
    public string AccessDeniedPath { get; set; } = null!;
    public string ReturnUrlParameter { get; set; } = null!;
    public int ExpireDay { get; set; }
}