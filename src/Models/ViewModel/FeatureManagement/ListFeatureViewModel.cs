using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.FeatureManagement;

public class ListFeatureViewModel
{
    [Display(Name = "Mã")]
    public int Id { get; set; }
    [Display(Name = "Tên tính năng")]
    public string Name { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Feature, ListFeatureViewModel>();
        }
    }
}