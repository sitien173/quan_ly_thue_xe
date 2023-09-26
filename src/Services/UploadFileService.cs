using System.Drawing;
using CarRentalManagement.Common;
using CarRentalManagement.Models.Settings;
using CarRentalManagement.Models.UploadFile;
using Microsoft.Extensions.Options;

namespace CarRentalManagement.Services;

public interface IUploadFileService : ITransientService
{ 
    Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request);
    void DeleteFile(string url);
}

public class UploadFileService : IUploadFileService
{
    private readonly IWebHostEnvironment  _hostEnvironment;
    private readonly CustomSettings _customSettings;
    public UploadFileService(IWebHostEnvironment hostEnvironment, IOptions<CustomSettings> customSettings)
    {
        _hostEnvironment = hostEnvironment;
        _customSettings = customSettings.Value;
    }
    
    public async Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request)
    {
        var response = new UploadFileResponse
        {
            FileName = GetUniqueFileName(request.File.FileName)
        };

        var uniqueFileName = GetUniqueFileName(request.File.FileName);
        
        var uploads = Path.Combine(_hostEnvironment.WebRootPath, _customSettings.UploadPath, uniqueFileName);
        await using var fileStream = new FileStream(uploads, FileMode.Create);
        await request.File.CopyToAsync(fileStream);
        
        var thumbUploads = Path.Combine(_hostEnvironment.WebRootPath, _customSettings.UploadThumbPath, uniqueFileName);
        AddThumbnailImage(request, thumbUploads);
        
        response.Url = "/" + _customSettings.UploadPath + "/" + uniqueFileName;
        response.ThumbUrl = "/" + _customSettings.UploadThumbPath + "/" + uniqueFileName;
        
        return response;
    }

    #pragma warning disable CA1416
    private static void AddThumbnailImage(UploadFileRequest request, string saveToDestination)
    {
        Image image = Image.FromStream(request.File.OpenReadStream());
        Image thumb = image.GetThumbnailImage(request.With, request.Height, ()=>false, IntPtr.Zero);
        thumb.Save(saveToDestination);
    }
    #pragma warning restore CA1416
    
    private string GetUniqueFileName(string fileName)
    {
        fileName = Path.GetFileName(fileName);
        return  Path.GetFileNameWithoutExtension(fileName)
                + "_" 
                + DateTime.Now.Ticks
                + Path.GetExtension(fileName);
    }

    public void DeleteFile(string url)
    {
        var filePath = Path.Combine(_hostEnvironment.WebRootPath, url.TrimStart('/'));

        if (!File.Exists(filePath))
            return;

        File.Delete(filePath);
    }
}