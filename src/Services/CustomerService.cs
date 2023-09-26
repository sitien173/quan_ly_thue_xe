using System.Linq.Expressions;
using Ardalis.GuardClauses;
using AutoMapper;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.UploadFile;
using CarRentalManagement.Models.ViewModel.Customer;
using CarRentalManagement.Models.ViewModel.CustomerManagement;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface ICustomerService : ICrudService<Customer, int>
{
    Task UpdateInformation(CustomerInformationViewModel model, int userId);
}

public class CustomerService : CrudService<Customer, int>, ICustomerService
{
    private readonly IUploadFileService _uploadFileService;

    private const string _emailExist = "Email {0} đã tồn tại";
    private const string _phoneExist = "Số điện thoại {0} đã tồn tại";
    private const string _idCardExist = "Số CMND {0} đã tồn tại";
    private const string _userNameExist = "Tên đăng nhập {0} đã tồn tại";

    public CustomerService(CarRentalDbContext context, IMapper mapper, IUploadFileService uploadFileService) : base(
        context, mapper)
    {
        _uploadFileService = uploadFileService;
    }

    protected override async Task ValidateBeforeUpdateAsync(Customer entity, object model)
    {
        var editViewModel = model as EditCustomerViewModel;
        Guard.Against.Null(editViewModel);

        if (!EntityHasChanged(entity, editViewModel.Email, editViewModel.Phone, editViewModel.IDCard,
                editViewModel.UserName))
            return;

        await EnsureCustomerDoesNotExist(editViewModel.Email, editViewModel.Phone, editViewModel.IDCard,
            editViewModel.UserName);
    }

    private bool EntityHasChanged(Customer entity, string email, string phone, string idCard, string userName)
    {
        return !entity.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
               || !entity.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase)
               || !entity.IDCard.Equals(idCard, StringComparison.OrdinalIgnoreCase)
               || !entity.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase);
    }

    private async Task<(string, string)> UpdatePhoto(IFormFile? photoFile, string deletedPhotoUrl,
        string deletedPhotoThumbUrl)
    {
        if(photoFile is null)
            return (deletedPhotoUrl, deletedPhotoThumbUrl);
        
        var uploadFileRequest = new UploadFileRequest(photoFile);
        var uploadFileResponse = await _uploadFileService.UploadFileAsync(uploadFileRequest).ConfigureAwait(false);

        _uploadFileService.DeleteFile(deletedPhotoUrl);
        _uploadFileService.DeleteFile(deletedPhotoThumbUrl);

        return (uploadFileResponse.Url, uploadFileResponse.ThumbUrl);
    }

    private async Task EnsureCustomerDoesNotExist(string email, string phone, string idCard, string userName)
    {
        Expression<Func<Customer, bool>> predicate = x =>
            !x.IsDeleted &&
            (x.Email == email || x.Phone == phone || x.IDCard == idCard || x.UserName == userName);

        var customerExist = await DbSet.FirstOrDefaultAsync(predicate);

        if (customerExist is null)
            return;

        Guard.Against.InvalidInput(customerExist.Email, nameof(email),
            x => !x.Equals(email, StringComparison.OrdinalIgnoreCase), string.Format(_emailExist, email));

        Guard.Against.InvalidInput(customerExist.Phone, nameof(phone),
            x => !x.Equals(phone, StringComparison.OrdinalIgnoreCase), string.Format(_phoneExist, phone));

        Guard.Against.InvalidInput(customerExist.IDCard, nameof(idCard),
            x => !x.Equals(idCard, StringComparison.OrdinalIgnoreCase), string.Format(_idCardExist, idCard));

        Guard.Against.InvalidInput(customerExist.UserName, nameof(userName),
            x => !x.Equals(userName, StringComparison.OrdinalIgnoreCase), string.Format(_userNameExist, userName));
    }

    public async Task UpdateInformation(CustomerInformationViewModel model, int userId)
    {
        var entity = await FindOrElseThrowAsync(userId).ConfigureAwait(false);

        if (EntityHasChanged(entity, model.Email, model.Phone, model.IDCard, model.UserName))
            await EnsureCustomerDoesNotExist(model.Email, model.Phone, model.IDCard, model.UserName);

        (model.FrontalPhoto, model.FrontalPhotoThumb) = await UpdatePhoto(model.FrontalPhotoFile, model.FrontalPhoto, model.FrontalPhotoThumb);
        (model.RearPhoto, model.RearPhotoThumb) = await UpdatePhoto(model.RearPhotoFile, model.FrontalPhoto, model.FrontalPhotoThumb);
        (model.Avatar, model.AvatarThumb) = await UpdatePhoto(model.AvatarFile, model.Avatar, model.AvatarThumb);
        
        Mapper.Map(model, entity);
        Context.Update(entity);
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }
}