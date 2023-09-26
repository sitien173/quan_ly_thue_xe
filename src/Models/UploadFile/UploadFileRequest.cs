namespace CarRentalManagement.Models.UploadFile;

public class UploadFileRequest
{
    public UploadFileRequest()
    {
        
    }

    public UploadFileRequest(IFormFile file)
    {
        File = file;
    }
    public IFormFile File { get; set; }
    public int With { get; set; } = 270;
    public int Height { get; set; } = 180;
}