using System.Linq.Expressions;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarRentalManagement.Common;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.FeatureManagement;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace CarRentalManagement.Services;

public interface IFeatureService : ICrudService<Feature, int>
{
}

public class FeatureService : CrudService<Feature, int>, IFeatureService
{
    public FeatureService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}