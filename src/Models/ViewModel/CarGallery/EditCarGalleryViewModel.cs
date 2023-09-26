using System.ComponentModel.DataAnnotations;
using CarRentalManagement.Interceptors.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.CarGallery;

public class EditCarGalleryViewModel
{
    public EditCarGalleryViewModel()
    {
        CarGalleryViewModels = new List<CarGalleryViewModel>();
        UploadImages = new FormFileCollection();
        ChangeCarGalleryViewModels = new List<ChangeCarGalleryViewModel>();
        DeleteImages = new List<int>();
    }
    public List<CarGalleryViewModel> CarGalleryViewModels { get; set; }
    
    [HiddenInput]
    public int CarId { get; set; }
    
    [HiddenInput]
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Thêm ảnh mới")]
    [DataType(DataType.Upload)]
    public IFormFileCollection UploadImages { get; set; }
    
    public List<int> DeleteImages { get; set; }
    public List<ChangeCarGalleryViewModel> ChangeCarGalleryViewModels { get; set; }
    
    public class ChangeCarGalleryViewModel
    {
        [HiddenInput]
        
        public int Id { get; set; }
        
        [Display(Name = "Thay đổi ảnh")]
        [ValidateFile]
        [DataType(DataType.Upload)]
        public IFormFile? UploadImage { get; set; }
    }
}