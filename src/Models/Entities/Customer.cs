namespace CarRentalManagement.Models.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Domicile { get; set; } = null!;
    public string TempAccommodation { get; set; } = null!;
    public string CurrentAddress { get; set; } = null!;
    public string Profession { get; set; } = null!;
    public string WorkPlace { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsVerify { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsLocked { get; set; }
    public string Avatar { get; set; } = null!;
    public string AvatarThumb { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public SexEnum SexEnum { get; set; }
    public string IDCard { get; set; } = null!;
    public DateTime DateOfIssue { get; set; }
    public string PlaceOfIssue { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public string FrontalPhoto { get; set; } = null!;
    public string FrontalPhotoThumb { get; set; } = null!;
    public string RearPhoto { get; set; } = null!;
    public string RearPhotoThumb { get; set; } = null!;
    public ICollection<License> Licenses { get; set; } = new List<License>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Follow> Follows { get; set; } = new List<Follow>();
    public ICollection<RentRequest> RentRequests { get; set; } = new List<RentRequest>();
}

