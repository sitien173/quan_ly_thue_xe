using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarRentalManagement.Data;
using CarRentalManagement.Extensions;
using CarRentalManagement.Models.Entities;
using CarRentalManagement.Models.UploadFile;
using CarRentalManagement.Models.ViewModel.Car;
using CarRentalManagement.Models.ViewModel.CarGallery;
using CarRentalManagement.Models.ViewModel.CarManagement;
using CarRentalManagement.Models.ViewModel.Home;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Services;

public interface ICarService : ICrudService<Car, int>
{
    Task<List<CarGalleryViewModel>> GetCarGalleriesAsync(int id);
    Task EditCarGalleriesAsync(EditCarGalleryViewModel model);
    Task<Page<CarFilterResponseViewModel>> FilterCarsAsync(CarFilterViewModel model);
    Task RentCarAsync(RentCarViewModel model);
    Task FollowCarAsync(int id, int userId);
    Task UnFollowCarAsync(int id, int userId);
    Task<List<ListCarViewModel>> GetTopCarRentAsync(int take = 10);
}

public class CarService : CrudService<Car, int>, ICarService
{
    private const string _carIsNotAvailable = "Xe không có sẵn để thuê trong khung giờ trên";
    private const string _carIsRepairing = "Xe đang được sửa chữa. Hiện không thể thuê";
    
    private readonly IUploadFileService _uploadFileService;

    public CarService(CarRentalDbContext context, IMapper mapper, IUploadFileService uploadFileService) : base(context, mapper)
    {
        _uploadFileService = uploadFileService;
    }

    protected override async Task ValidateBeforeAddAsync(object model)
    {
        var addCarViewModel = model as AddCarViewModel;
        Guard.Against.Null(addCarViewModel);
        
        var existLicensePlate = await DbSet.AnyAsync(x => x.LicensePlate == addCarViewModel.LicensePlate).ConfigureAwait(false);
        Guard.Against.InvalidInput(!existLicensePlate, nameof(addCarViewModel.LicensePlate), x => x,
            "Biển số xe đã tồn tại");
    }

    protected override async Task AdditionToEntityBeforeAddAsync(Car persistence, object model)
    {
        var addCarViewModel = model as AddCarViewModel;
        Guard.Against.Null(addCarViewModel);
        
        var uploadImageTasks = addCarViewModel.UploadImages.Select(x => _uploadFileService.UploadFileAsync(new UploadFileRequest(x))).ToArray();
        await Task.WhenAll(uploadImageTasks).ConfigureAwait(false);
        
        foreach (var uploadFileResponse in uploadImageTasks.Select(x => x.GetAwaiter().GetResult()))
            persistence.CarPhotoGalleries.Add(new CarPhotoGallery { Url = uploadFileResponse.Url, ThumbUrl = uploadFileResponse.ThumbUrl});
        
        foreach (var featureId in addCarViewModel.FeatureIds)
            persistence.CarFeatures.Add(new CarFeature() {FeatureId = featureId});
    }
    
    public async Task<List<CarGalleryViewModel>> GetCarGalleriesAsync(int id)
    {
        var entity = await FindOrElseThrowAsync(id).ConfigureAwait(false);
        await DbSet.Attach(entity).Collection(x => x.CarPhotoGalleries).LoadAsync();
        return entity.CarPhotoGalleries
            .Select(x => new CarGalleryViewModel { Id = x.Id, Url = x.Url, ThumbUrl = x.ThumbUrl })
            .ToList();
    }

    public async Task EditCarGalleriesAsync(EditCarGalleryViewModel model)
    {
        var entity = await FindOrElseThrowAsync(model.CarId).ConfigureAwait(false);
        await DbSet.Attach(entity).Collection(x => x.CarPhotoGalleries).LoadAsync();

        var changeCarGalleryViewModels = model.ChangeCarGalleryViewModels
            .Where(x => x.UploadImage != null).ToArray();

        model.DeleteImages
            .Union(changeCarGalleryViewModels.Select(x => x.Id))
            .ToList()
            .ForEach(x => DeleteCarGallery(entity.CarPhotoGalleries, x));

        var uploadImageTasks = changeCarGalleryViewModels
            .Select(x => x.UploadImage)
            .Union(model.UploadImages)
            .Select(x => _uploadFileService.UploadFileAsync(new UploadFileRequest(x!)))
            .ToArray();

        await Task.WhenAll(uploadImageTasks).ConfigureAwait(false);

        foreach (var uploadFileResponse in uploadImageTasks.Select(x => x.GetAwaiter().GetResult()))
        {
            entity.CarPhotoGalleries.Add(new CarPhotoGallery { Url = uploadFileResponse.Url, ThumbUrl = uploadFileResponse.ThumbUrl});
        }
        
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }
    
    private void DeleteCarGallery(ICollection<CarPhotoGallery> carPhotoGalleries, int carPhotoGalleryId)
    {
        var gallery = carPhotoGalleries.FirstOrDefault(x => x.Id == carPhotoGalleryId);

        if (gallery == null)
            return;
            
        carPhotoGalleries.Remove(gallery);
        
        _uploadFileService.DeleteFile(gallery.Url);
        _uploadFileService.DeleteFile(gallery.ThumbUrl);
    }

    public async Task<Page<CarFilterResponseViewModel>> FilterCarsAsync(CarFilterViewModel model)
    {
        var queryable = DbSet.AsNoTracking().Where(x => !x.IsDeleted && !x.IsRepairing);
        
        queryable = queryable.AddWhereClause(x => x.Name.Contains(model.TxtText!), !string.IsNullOrEmpty(model.TxtText));
        queryable = queryable.AddWhereClause(x => x.TransmissionEnum == model.TransmissionEnum, model.TransmissionEnum.HasValue);
        queryable = queryable.AddWhereClause(x => x.FuelEnum == model.FuelEnum, model.FuelEnum.HasValue);
        queryable = queryable.AddWhereClause(x => x.BrandId == model.BrandId, model.BrandId.HasValue);
        queryable = queryable.AddWhereClause(x => x.Seat == model.Seat, model.Seat.HasValue);
        queryable = queryable.AddWhereClause(x => x.ManufactureYear == model.ManufactureYear, model.ManufactureYear.HasValue);
        queryable = queryable.AddWhereClause(x => x.CarTypeId == model.CarTypeId, model.CarTypeId.HasValue);
        queryable = queryable.AddWhereClause(x => x.CarFeatures.Any(y => model.FeatureIds.Contains(y.FeatureId)), model.FeatureIds.Any());
        
        bool hasValueRental = model is { RentalDate: not null, ReturnedDate: not null };
        queryable = queryable.AddWhereClause(x => x.RentRequests.All(xx => (xx.ReturnedDate < model.RentalDate || xx.RentalDate > model.ReturnedDate) && !x.IsDeleted), hasValueRental);
        
        var responsePage = new Page<CarFilterResponseViewModel>
        {
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = await queryable.CountAsync().ConfigureAwait(false)
        };

        responsePage.TotalPages = (int) Math.Ceiling(responsePage.TotalRecords / (double) model.PageSize);
        responsePage.Data = await queryable.Where(x => !x.IsDeleted)
            .OrderBy(x => x.Id)
            .Skip((model.PageNumber - 1) * model.PageSize)
            .Take(model.PageSize)
            .ProjectTo<CarFilterResponseViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync().ConfigureAwait(false);
        return responsePage;
    }
    
    public async Task RentCarAsync(RentCarViewModel model)
    {
        var entity = await GetAsync(x => x.Id == model.CarId && !x.IsDeleted, 
                i => i.RentRequests, i => i.ContractDetails)
                .ConfigureAwait(false);
        
        Guard.Against.Null(entity);
        Guard.Against.AgainstExpression(x => x, !entity.IsRepairing, _carIsRepairing);

        bool isAvailable = entity.RentRequests.All(x => (x.ReturnedDate < model.StartDate || x.RentalDate > model.EndDate) && !x.IsDeleted);
        Guard.Against.InvalidInput(isAvailable, string.Empty, x => x, _carIsNotAvailable);
        
        var estimate = await Context.Estimate.FindAsync(model.EstimateId).ConfigureAwait(false);
        Guard.Against.Null(estimate);
        
        decimal totalPrice = (model.EndDate - model.StartDate).Days * estimate.UnitPrice;
        var rentRequest = new RentRequest()
        {
            CarId = model.CarId,
            CustomerId = model.CustomerId,
            RentalDate = model.StartDate,
            ReturnedDate = model.EndDate,
            RentalMethod = estimate.RentalMethod,
            Note = model.Note,
            RentRequestStatusEnum = RentRequestStatusEnum.Pending,
            TotalPrice = totalPrice
        };
        entity.RentRequests.Add(rentRequest);
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }
    
    public async Task FollowCarAsync(int id, int userId)
    {
        var entity = await FindOrElseThrowAsync(id).ConfigureAwait(false);
        var entryCar = DbSet.Attach(entity);
        
        await entryCar.Collection(x => x.Follows).LoadAsync().ConfigureAwait(false);
        
        var isFollowed = entity.Follows.Any(x => x.CustomerId == userId);
        if(isFollowed)
            return;
        
        entity.Follows.Add(new Follow()
        {
            CustomerId = userId
        });
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task UnFollowCarAsync(int id, int userId)
    {
        var entity = await FindOrElseThrowAsync(id).ConfigureAwait(false);
        var entryCar = DbSet.Attach(entity);
        
        await entryCar.Collection(x => x.Follows).LoadAsync().ConfigureAwait(false);
        
        var follow = entity.Follows.First(x => x.CustomerId == userId && x.CarId == id);
        entity.Follows.Remove(follow);
        
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }

    public Task<List<ListCarViewModel>> GetTopCarRentAsync(int take = 10)
    {
        return DbSet.AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.ContractDetails.Count)
            .Take(take)
            .ProjectTo<ListCarViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }
}