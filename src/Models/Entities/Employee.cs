namespace CarRentalManagement.Models.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public SexEnum SexEnum { get; set; }
    public DateTime? BirthDate { get; set; }
    public RoleEnum RoleEnum { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? CreatedBy { get; set; }
}