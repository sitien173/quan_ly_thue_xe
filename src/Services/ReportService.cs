using System.Linq.Expressions;
using CarRentalManagement.Data;
using CarRentalManagement.Extensions;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.Report;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface IReportService : IScopedService
{
    Task<RevenueResponseViewModel> GetRevenueAsync(RevenueRequest request);
}

public class ReportService : IReportService
{
    private readonly CarRentalDbContext _context;

    public ReportService(CarRentalDbContext context)
    {
        _context = context;
    }

    public async Task<RevenueResponseViewModel> GetRevenueAsync(RevenueRequest request)
    {
        var revenueViewModel = new RevenueResponseViewModel();
        var invoices = _context.Invoice
            .Where(x => !x.IsDeleted)
            .AddWhereClause(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate, request is { StartDate: { }, EndDate: { } });
        
        var groupByFunc = request.ReportType switch
        {
            ReportTypeEnum.Month => (Expression<Func<Invoice, int>>)(x => x.CreatedAt.Month),
            _ => x => x.CreatedAt.Year
        };
        
        var data = await invoices
            .GroupBy(groupByFunc)
            .Select(group => new 
            {
                Label = group.Key.ToString(),
                Value = group.Sum(x => x.TotalPriceWithVat)
            })
            .ToListAsync().ConfigureAwait(false);

        revenueViewModel.Data.Datasets.Add(new ()
        {
            Label = $"Doanh thu theo {request.ReportType.GetDescription().ToLower()}",
            Data = data.Select(x => x.Value)
            
        });
        revenueViewModel.Data.Labels = data.Select(x => x.Label).ToArray();
        return revenueViewModel;

    }
}