namespace CarRentalManagement.Models.Entities;

public class License
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Grade { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string? PlaceOfIssue { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string FrontalPhoto { get; set; }
    public string FrontalPhotoThumb { get; set; }
    public string RearPhoto { get; set; }
    public string RearPhotoThumb { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}