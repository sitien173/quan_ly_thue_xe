namespace CarRentalManagement.Models.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public SexEnum SexEnum { get; set; }
    public DateTime? BirthDate { get; set; }
    public RoleEnum RoleEnum { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? CreatedBy { get; set; }
}