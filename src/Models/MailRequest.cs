namespace CarRentalManagement.Models;

public class MailRequest
{
    public MailRequest()
    {
        Attachments = Enumerable.Empty<IFormFile>();
    }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public IEnumerable<IFormFile> Attachments { get; set; }
}