using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel;

public class AddContactViewModel
{
    [Required]
    [Display(Name = "Họ và tên")]
    public string FullName { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Required]
    [Display(Name = "Tiêu đề")]
    public string Subject { get; set; }
    
    [Required]
    [Display(Name = "Nội dung")]
    public string Message { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddContactViewModel, Contact>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => System.DateTime.Now));
        }
    }
}