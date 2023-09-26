using System.Linq.Expressions;
using System.Security.Claims;
using Ardalis.GuardClauses;
using AsyncAwaitBestPractices;
using AutoMapper;
using CarRentalManagement.Common;
using CarRentalManagement.Data;
using CarRentalManagement.Models;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.Settings;
using CarRentalManagement.Models.UploadFile;
using CarRentalManagement.Models.ViewModel.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CarRentalManagement.Services;

public interface IAuthService : IScopedService
{
    Task CreateAsync(RegistrationViewModel model);
    Task VerifyAsync(string token);
    Task<ClaimsPrincipal> LoginAsync(LoginViewModel model, LoginMode mode = LoginMode.Customer);
    Task ResetPasswordAsync(string email);
    Task ChangePasswordAsync(ChangePasswordViewModel model);
}

public class AuthService : IAuthService
{
    private readonly IUploadFileService _uploadFileService;
    private readonly IOptions<CustomSettings> _customSettings;
    private readonly IOptions<CookiesSettings> _cookiesSettings;
    private readonly IEmailService _emailService;
    private readonly DbSet<Customer> _dbSet;
    private readonly IMapper _mapper;
    private readonly CarRentalDbContext _context;

    private const string _employeeNotFound = "Nhân viên không tồn tại";
    private const string _customerNotFound = "Khách hàng không tồn tại";
    private const string _emailExist = "Email {0} đã tồn tại";
    private const string _phoneExist = "Số điện thoại {0} đã tồn tại";
    private const string _idCardExist = "Số CMND {0} đã tồn tại";
    private const string _userNameExist = "Tên đăng nhập {0} đã tồn tại";
    private const string _licenseExist = "Giấy phép lái xe {0} đã tồn tại";
    
    public AuthService(CarRentalDbContext context, IUploadFileService uploadFileService, IMapper mapper, IEmailService emailService, IOptions<CustomSettings> customSettings, IOptions<CookiesSettings> cookiesSettings) 
    {
        _uploadFileService = uploadFileService;
        _emailService = emailService;
        _customSettings = customSettings;
        _cookiesSettings = cookiesSettings;
        _dbSet = context.Customer;
        _mapper = mapper;
        _context = context;
    }
    public async Task CreateAsync(RegistrationViewModel model)
    {
        Expression<Func<Customer, bool>> predicate = x =>
            !x.IsDeleted && 
            x.Email == model.Email || 
            x.Phone == model.Phone || 
            x.IDCard == model.IDCard ||
            x.UserName == model.UserName;
            
        var customerExist = await _dbSet.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        if (customerExist != null)
        {
            Guard.Against.InvalidInput(customerExist.Email, nameof(model.Email),
                x => !x.Equals(model.Email, StringComparison.OrdinalIgnoreCase), string.Format(_emailExist, model.Email));
                
            Guard.Against.InvalidInput(customerExist.Phone, nameof(model.Phone),
                x => !x.Equals(model.Phone, StringComparison.OrdinalIgnoreCase), string.Format(_phoneExist, model.Phone));
                
            Guard.Against.InvalidInput(customerExist.IDCard, nameof(model.IDCard),
                x => !x.Equals(model.IDCard, StringComparison.OrdinalIgnoreCase), string.Format(_idCardExist, model.IDCard));
                
            Guard.Against.InvalidInput(customerExist.UserName, nameof(model.UserName),
                x => !x.Equals(model.UserName, StringComparison.OrdinalIgnoreCase), string.Format(_userNameExist, model.UserName));
        }
        
        // check license is exist
        var licenseExist = await _context.License.AnyAsync(x => x.Number == model.LicenseViewModels.Number).ConfigureAwait(false);
        Guard.Against.InvalidInput(!licenseExist, nameof(model.Email),
            x => x, string.Format(_licenseExist, model.LicenseViewModels.Number));
        
        var customer = _mapper.Map<Customer>(model);

        var uploadFileTasks = new List<Task<UploadFileResponse>>();
        
        var uploadAvatarRequest = new UploadFileRequest() { File = model.Avatar };
        var uploadAvatarResponseTask = _uploadFileService.UploadFileAsync(uploadAvatarRequest);
        uploadFileTasks.Add(uploadAvatarResponseTask);
        
        var uploadFrontalPhotoRequest = new UploadFileRequest() { File = model.FrontalPhoto };
        var uploadFrontalPhotoResponseTask = _uploadFileService.UploadFileAsync(uploadFrontalPhotoRequest);
        uploadFileTasks.Add(uploadFrontalPhotoResponseTask);
        
        var uploadRearPhotoRequest = new UploadFileRequest() { File = model.RearPhoto };
        var uploadRearPhotoResponseTask = _uploadFileService.UploadFileAsync(uploadRearPhotoRequest);
        uploadFileTasks.Add(uploadRearPhotoResponseTask);   
        
        var uploadLicenseFrontalPhotoRequest = new UploadFileRequest() { File = model.LicenseViewModels.FrontalPhotoFile };
        var uploadLicenseFrontalPhotoResponseTask = _uploadFileService.UploadFileAsync(uploadLicenseFrontalPhotoRequest);
        uploadFileTasks.Add(uploadLicenseFrontalPhotoResponseTask);   
        
        var uploadLicenseRearPhotoRequest = new UploadFileRequest() { File = model.LicenseViewModels.RearPhotoFile };
        var uploadLicenseRearPhotoResponseTask = _uploadFileService.UploadFileAsync(uploadLicenseRearPhotoRequest);
        uploadFileTasks.Add(uploadLicenseRearPhotoResponseTask);   
        
        await Task.WhenAll(uploadFileTasks).ConfigureAwait(false);

        customer.Avatar = (await uploadAvatarResponseTask).Url;
        customer.AvatarThumb =(await uploadAvatarResponseTask).ThumbUrl;
        
        customer.Password = PasswordHelper.HashPassword(customer.Password);
        customer.IsVerify = false;
        
        customer.FrontalPhoto = (await uploadFrontalPhotoResponseTask).Url;
        customer.FrontalPhotoThumb = (await uploadFrontalPhotoResponseTask).ThumbUrl;
        
        customer.RearPhoto = (await uploadRearPhotoResponseTask).Url;
        customer.RearPhotoThumb = (await uploadRearPhotoResponseTask).ThumbUrl;
        
        customer.Licenses.Add(new License()
        {
            Number = model.LicenseViewModels.Number,
            DateOfIssue = model.LicenseViewModels.DateOfIssue,
            ExpirationDate = model.LicenseViewModels.ExpirationDate,
            FrontalPhoto = (await uploadLicenseFrontalPhotoResponseTask).Url,
            FrontalPhotoThumb = (await uploadLicenseFrontalPhotoResponseTask).ThumbUrl,
            RearPhoto = (await uploadLicenseRearPhotoResponseTask).Url,
            RearPhotoThumb = (await uploadLicenseRearPhotoResponseTask).ThumbUrl,
            Grade = model.LicenseViewModels.Grade,
            PlaceOfIssue = model.LicenseViewModels.PlaceOfIssue
        });
        
        var maThongBao = new Notification()
        {
            CreatedAt = DateTime.Now,
            ExpirationAt = DateTime.Now.AddDays(1),
            IsConfirm = false,
            Token = Guid.NewGuid().ToString()
        };
        customer.Notifications.Add(maThongBao);
        
        await _dbSet.AddAsync(customer).ConfigureAwait(false);
        
        var mailRequest = new MailRequest()
        {
            ToEmail = model.Email,
            Subject = "Xác thực địa chỉ email",
            Body = $"<h1>Xin chào {model.FirstName} {model.LastName}</h1><p>Vui lòng nhấn vào link sau để xác thực địa chỉ email của bạn: <a href='{_customSettings.Value.BaseUrl}/auth/verify?token={maThongBao.Token}?returnUrl={model.ReturnUrl}'>Xác thực</a></p>"
        };

        _emailService.SendEmailAsync(mailRequest).SafeFireAndForget();
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
    
    public async Task VerifyAsync(string token)
    {
        var verifyToken = await _context.Notification.FirstOrDefaultAsync(x => x.Token == token).ConfigureAwait(false);
        Guard.Against.Null(verifyToken, nameof(token), "Mã xác thực không tồn tại");
        Guard.Against.InvalidInput(verifyToken, string.Empty, x => !x.IsConfirm, "Mã xác thực đã được kích hoạt");
        Guard.Against.InvalidInput(verifyToken, string.Empty, x => DateTime.Now < x.ExpirationAt, "Mã xác thực đã hết hạn");
        
        verifyToken.IsConfirm = true;
        verifyToken.Customer.IsVerify = true;
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<ClaimsPrincipal> LoginAsync(LoginViewModel model, LoginMode mode = LoginMode.Customer)
    {
        return mode switch
        {
            LoginMode.Employee => await LoginEmployeeAsync(model).ConfigureAwait(false),
            _ => await LoginCustomerAsync(model).ConfigureAwait(false)
        };
    }

    private async Task<ClaimsPrincipal> LoginCustomerAsync(LoginViewModel model)
    {
        var customer = await _dbSet.FirstOrDefaultAsync(x => x.UserName == model.UserName).ConfigureAwait(false);
        Guard.Against.Null(customer, nameof(model.UserName), _customerNotFound);
        Guard.Against.InvalidInput(customer, string.Empty, x => x.IsVerify, "tài khoản chưa xác thực");
        Guard.Against.InvalidInput(customer, string.Empty, x => !x.IsLocked, "tài khoản đã bị khoá");
        Guard.Against.InvalidInput(model.Password, nameof(model.Password), x => PasswordHelper.VerifyPassword(x, customer.Password), "Mật khẩu không đúng");

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new (ClaimTypes.Name, $"{customer.FirstName} {customer.LastName}"),
        };
        
        return new ClaimsPrincipal(new ClaimsIdentity(claims, _cookiesSettings.Value.AuthenticationScheme));
    }
    
    private async Task<ClaimsPrincipal> LoginEmployeeAsync(LoginViewModel model)
    {
        var employee = await _context.Employee.FirstOrDefaultAsync(x => x.UserName == model.UserName).ConfigureAwait(false);
        Guard.Against.Null(employee, nameof(model.UserName), _employeeNotFound);
        Guard.Against.InvalidInput(employee, string.Empty, x => !x.IsDeleted, "tài khoản đã bị xoá");
        Guard.Against.InvalidInput(model.Password, nameof(model.Password), x => PasswordHelper.VerifyPassword(x, employee.Password), "Mật khẩu không đúng");

        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new (ClaimTypes.Role, employee.RoleEnum.ToString()),
            new (ClaimTypes.Name, employee.FullName),
        };
        return new ClaimsPrincipal(new ClaimsIdentity(claims, _cookiesSettings.Value.AuthenticationScheme));
    }

    public async Task ResetPasswordAsync(string email)
    {
        var customer = await _dbSet.FirstOrDefaultAsync(x => x.Email == email).ConfigureAwait(false);
        Guard.Against.Null(customer, string.Empty, _customerNotFound);
        Guard.Against.InvalidInput(customer, string.Empty, x => x.IsVerify, "tài khoản chưa xác thực");
        Guard.Against.InvalidInput(customer, string.Empty, x => !x.IsLocked, "tài khoản đã bị khoá");
        
        customer.Password = PasswordHelper.GeneratePassword();
        var mailRequest = new MailRequest()
        {
            ToEmail = email,
            Subject = "Mật khẩu mới",
            Body = $"<h1>Xin chào {customer.FirstName} {customer.LastName}</h1><p>Thông tin đăng nhập mới của bạn là:</p><p>Email: {customer.Email}</p><p>Mật khẩu: {customer.Password}</p><p></p><p>Vui lòng đăng nhập và đổi mật khẩu mới</p>"
        };

        _emailService.SendEmailAsync(mailRequest).SafeFireAndForget();
        _dbSet.Update(customer);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task ChangePasswordAsync(ChangePasswordViewModel model)
    {
        var customer = await _dbSet.FirstOrDefaultAsync(x => x.Id == model.CustomerId).ConfigureAwait(false);
        Guard.Against.Null(customer, nameof(model.CustomerId), _customerNotFound);
        
        Guard.Against.InvalidInput(model.CurrentPassword, nameof(model.CurrentPassword), x => PasswordHelper.VerifyPassword(x, customer.Password), "Mật khẩu cũ không đúng");
        Guard.Against.InvalidInput(model.NewPassword, nameof(model.NewPassword), x => x.Equals(model.ConfirmPassword), "Mật khẩu mới không khớp");
        
        customer.Password = PasswordHelper.HashPassword(model.NewPassword);
        _dbSet.Update(customer);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}