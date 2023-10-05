namespace CarRentalManagement.Models.Entities;

public class License
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public string Grade { get; set; } = null!;
    public DateTime DateOfIssue { get; set; }
    public string? PlaceOfIssue { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string FrontalPhoto { get; set; } = null!;
    public string FrontalPhotoThumb { get; set; } = null!;
    public string RearPhoto { get; set; } = null!;
    public string RearPhotoThumb { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}