namespace CarRentalManagement.Models.Entities;

public class Customer
{
    public Customer()
    {
        Licenses = new List<License>();
        Notifications = new List<Notification>();
        Follows = new List<Follow>();
        RentRequests = new List<RentRequest>();
    }
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
    public string Password { get; set; }
    public bool IsVerify { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsLocked { get; set; }
    public string Avatar { get; set; }
    public string AvatarThumb { get; set; }
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
    public ICollection<License> Licenses { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Follow> Follows { get; set; }
    public ICollection<RentRequest> RentRequests { get; set; }
}

