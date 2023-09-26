﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;

namespace CarRentalManagement.Models.ViewModel.AccidentManagement;

public class ListAccidentViewModel
{
    [Display(Name = "Mã tai nạn")]
    public int Id { get; set; }
    
    [Display(Name = "Mã xe")]
    public int CarId { get; set; }
    
    [Display(Name = "Mã hợp đồng")]
    public int ContractId { get; set; }
    
    [Display(Name = "Ngày tai nạn")]
    public DateTime? AccidentAt { get; set; }
    
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }
    
    [Display(Name = "Ngày tạo")]
    public DateTime CreatedAt { get; set; }
    
    [Display(Name = "Người tạo")]
    public int CreatedBy { get; set; }
    
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Accident, ListAccidentViewModel>();
        }
    }
}

