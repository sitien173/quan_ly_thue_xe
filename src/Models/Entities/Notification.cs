namespace CarRentalManagement.Models.Entities;

public class Notification
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpirationAt { get; set; }
    public bool IsConfirm { get; set; }
    public string Token { get; set; }
    public Customer Customer { get; set; }
}