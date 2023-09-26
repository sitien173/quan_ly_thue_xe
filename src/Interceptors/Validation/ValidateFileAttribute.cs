using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Interceptors.Validation;

public class ValidateFileAttribute : ValidationAttribute
{
    private readonly string[] _extensions = {".jpg", ".jpeg", ".png", ".gif"};
    private const string _defaultErrorMessage = "Chỉ chấp nhận file ảnh";
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        switch (value)
        {
            case IFormFile file:
            {
                return Validate(Path.GetExtension(file.FileName));
            }
            case IFormFileCollection files:
            {
                var result = files.Any(x => Validate(Path.GetExtension(x.FileName)) != ValidationResult.Success);
                return result ? new ValidationResult(_defaultErrorMessage) : ValidationResult.Success!;
            }
            default:
                return ValidationResult.Success!;
        }
    }
    
    private ValidationResult Validate(string extension, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        var isImage = _extensions.Any(ext => ext.Equals(extension, stringComparison));
        return isImage ? ValidationResult.Success! : new ValidationResult(_defaultErrorMessage);
    }
}