using System.Linq.Expressions;
using Ardalis.GuardClauses;
using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.ViewModel.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface IEmployeeService : ICrudService<Employee, int>
{
}

public class EmployeeService : CrudService<Employee, int>, IEmployeeService
{
    public EmployeeService(CarRentalDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override async Task ValidateBeforeAddAsync(object model)
    {
        var viewModel = model as AddEmployeeViewModel;
        Guard.Against.Null(viewModel);
        
        await ThrowIfDuplicatedUniqueValueAsync(viewModel.Email, viewModel.UserName).ConfigureAwait(false);
    }

    protected override async Task ValidateBeforeUpdateAsync(Employee entity, object model)
    {
        var viewModel = model as EditEmployeeViewModel;
        Guard.Against.Null(viewModel);
        
        if (!entity.Email.Equals(viewModel.Email, StringComparison.OrdinalIgnoreCase) ||
            !entity.UserName.Equals(viewModel.UserName, StringComparison.OrdinalIgnoreCase))
        {
            await ThrowIfDuplicatedUniqueValueAsync(viewModel.Email, viewModel.UserName).ConfigureAwait(false);
        }
    }

    private async Task ThrowIfDuplicatedUniqueValueAsync(string email, string username)
    {
        Expression<Func<Employee, bool>> predicate = x => !x.IsDeleted && x.Email == email || x.UserName == username;
        var entity = await DbSet.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        
        if (entity is null)
            return;
        
        Guard.Against.InvalidInput(entity.Email, string.Empty, x => !x.Equals(email, StringComparison.OrdinalIgnoreCase), "Email đã tồn tại");
        Guard.Against.InvalidInput(entity.UserName, string.Empty, x => !x.Equals(username, StringComparison.OrdinalIgnoreCase), "Tên đăng nhập đã tồn tại");
    }
}