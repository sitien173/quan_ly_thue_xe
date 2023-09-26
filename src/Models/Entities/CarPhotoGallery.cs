namespace CarRentalManagement.Models.Entities;

public class CarPhotoGallery
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string ThumbUrl { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
}