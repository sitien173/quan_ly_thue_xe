using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.CarTypeManagement;

public class ListCarTypeViewModel
{
    [Display(Name = "Mã loại xe")]
    public int Id { get; set; }
    [Display(Name = "Tên loại xe")]
    public string Name { get; set; }
    
    [Display(Name = "Biểu tượng")]
    public string Icon { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarType, ListCarTypeViewModel>();
        }
    }
}