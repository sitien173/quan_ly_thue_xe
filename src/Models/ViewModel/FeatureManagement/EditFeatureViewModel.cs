﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarRentalManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Models.ViewModel.FeatureManagement;

public class EditFeatureViewModel
{
    [HiddenInput]
    
    public int Id { get; set; }
    [HiddenInput]
    
    public string? ReturnUrl { get; set; }
    
    [Display(Name = "Tên tính năng")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên tính năng không được để trống")]
    public string Name { get; set; }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<EditFeatureViewModel, Feature>().ReverseMap();
        }
    }
}