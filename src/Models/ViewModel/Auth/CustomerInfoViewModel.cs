namespace CarRentalManagement.Models.ViewModel.Auth;

public class CustomerInfoViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Domicile { get; set; }
    public string TempAccommodation { get; set; }
    public string CurrentAddress { get; set; }
    public string Profession { get; set; }
    public string WorkPlace { get; set; }
    public string UserName { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarThumb { get; set; }
    public DateTime? CreatedAt { get; set; }
    public SexEnum SexEnum { get; set; }
    public string IDCard { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string PlaceOfIssue { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string FrontalPhoto { get; set; }
    public string FrontalPhotoThumb { get; set; }
    public string RearPhoto { get; set; }
    public string RearPhotoThumb { get; set; }
}