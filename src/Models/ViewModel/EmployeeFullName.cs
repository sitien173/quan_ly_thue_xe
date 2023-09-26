using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel;

public class EmployeeFullName
{
    public string FullName { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeFullName>();
        }
    }
}