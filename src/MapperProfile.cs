using AutoMapper;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.Auth;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CarRentalManagement;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RentRequest, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<Brand, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - {x.Name}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<CarType, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - {x.Name}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<Feature, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - {x.Name}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<Contract, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Id.ToString()))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<Car, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - {x.Name}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
        
        CreateMap<Customer, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - {x.FirstName} {x.LastName}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
    
        CreateMap<CarTransferAgreement, SelectListItem>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => $"{x.Id} - HĐ: {x.ContractId}  - Xe: {x.CarId}"))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()));
    }
}