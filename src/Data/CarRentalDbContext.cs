using CarRentalManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Data;

public class CarRentalDbContext : DbContext
{
    private const int _sizeDecimal = 12;
    private const int _sizeDecimalScale = 0;

    public DbSet<Estimate> Estimate { get; set; }
    public DbSet<ContractDetail> ContractDetail { get; set; }
    public DbSet<License> License { get; set; }
    public DbSet<CarPhotoGallery> CarPhotoGallery { get; set; }
    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<Contract> Contract { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<CarType> CarType { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Feature> Feature { get; set; }
    public DbSet<Car> Car { get; set; }
    public DbSet<RentRequest> RentRequest { get; set; }
    public DbSet<SurCharge> SurCharge { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<Damages> Damages { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    
    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity classes and their relationships here
        var estimate = modelBuilder.Entity<Estimate>();
        estimate.HasKey(x => x.Id);
        estimate.Property(x => x.UnitPrice).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        estimate.Property(x => x.Id)
            .UseIdentityColumn();

        estimate.Property(x => x.RentalMethod)
            .HasConversion(
                v => v.ToString(),
                v => (RentalMethodEnum)Enum.Parse(typeof(RentalMethodEnum), v))
            .IsUnicode(false);

        estimate.HasOne(x => x.CarType)
            .WithMany(x => x.Estimates)
            .HasForeignKey(x => x.CarTypeId);
        
        var contractDetail = modelBuilder.Entity<ContractDetail>();
        contractDetail.HasKey(x => x.Id);
        
        contractDetail.Property(x => x.Id)
            .UseIdentityColumn();
        
        contractDetail.Property(x => x.UnitPrice).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        contractDetail.Property(x => x.Price).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        contractDetail.Property(x => x.RentalMethod)
            .HasConversion(
                v => v.ToString(),
                v => (RentalMethodEnum)Enum.Parse(typeof(RentalMethodEnum), v))
            .IsUnicode(false);

        contractDetail.HasOne(x => x.Car)
            .WithMany(x => x.ContractDetails)
            .HasForeignKey(x => x.CarId);
        
        contractDetail.HasOne(x => x.Contract)
            .WithMany(x => x.ContractDetails)
            .HasForeignKey(x => x.ContractId);
        
        var license = modelBuilder.Entity<License>();
        license.HasKey(x => x.Id);
        license.Property(x => x.Id)
            .UseIdentityColumn();

        license.HasIndex(x => x.Number)
            .IsUnique();

        var carPhotoGallery = modelBuilder.Entity<CarPhotoGallery>();
        carPhotoGallery.HasKey(x => x.Id);
        carPhotoGallery.Property(x => x.Id)
            .UseIdentityColumn();

        var invoice = modelBuilder.Entity<Invoice>();
        invoice.HasKey(x => x.Id);
        invoice.Property(x => x.Id)
            .UseIdentityColumn();

        invoice.Property(x => x.UnitPrice).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        invoice.Property(x => x.TotalPriceWithVat).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        
        var contract = modelBuilder.Entity<Contract>();
        contract.HasKey(x => x.Id);
        contract.Property(x => x.Id)
            .UseIdentityColumn();

        contract.HasMany(x => x.Invoices)
            .WithOne(x => x.Contract)
            .HasForeignKey(x => x.ContractId);

        contract.HasOne(x => x.RentRequest)
            .WithOne(x => x.Contract)
            .HasForeignKey<Contract>(x => x.RentRequestId)
            .OnDelete(DeleteBehavior.NoAction);

        contract.Property(x => x.CreatedAt)
            .HasDefaultValueSql("getdate()");

        contract.Property(x => x.Total).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        contract.Property(x => x.Prepay).HasPrecision(_sizeDecimal, _sizeDecimalScale);

        var customer = modelBuilder.Entity<Customer>();
        customer.HasKey(x => x.Id);
        customer.Property(x => x.Id)
            .UseIdentityColumn();

        customer.HasIndex(x => new
            {
                x.Email, DienThoai = x.Phone, SoCCCD = x.IDCard, x.UserName
            })
            .IsUnique();

        customer.Property(x => x.SexEnum)
            .HasConversion(
                v => v.ToString(),
                v => (SexEnum)Enum.Parse(typeof(SexEnum), v))
            .IsUnicode(false);

        customer.Property(x => x.IsVerify)
            .HasDefaultValue(0);

        customer.Property(x => x.IsLocked)
            .HasDefaultValue(0);

        customer.HasMany(x => x.Licenses)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);

        customer.HasMany(x => x.Notifications)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);
        
        var carType = modelBuilder.Entity<CarType>();
        carType.HasKey(x => x.Id);
        carType.Property(x => x.Id)
            .UseIdentityColumn();

        carType.HasMany(x => x.Cars)
            .WithOne(x => x.CarType)
            .HasForeignKey(x => x.CarTypeId);
        
        carType.Property(x => x.IsDeleted)
            .HasDefaultValue(0);

        var notification = modelBuilder.Entity<Notification>();
        notification.HasKey(x => x.Id);
        notification.Property(x => x.Id)
            .UseIdentityColumn();

        notification.HasIndex(x => x.Token).IsUnique();

        notification.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.Now);

        notification.Property(x => x.IsConfirm)
            .HasDefaultValue(0);

        var employee = modelBuilder.Entity<Employee>();
        employee.HasKey(x => x.Id);
        employee.Property(x => x.Id)
            .UseIdentityColumn();

        employee.HasIndex(x => new { x.Email, x.UserName }).IsUnique();

        employee.Property(x => x.IsDeleted)
            .HasDefaultValue(0);

        employee.Property(x => x.CreatedAt)
            .HasDefaultValueSql("getdate()");

        employee.Property(x => x.SexEnum)
            .HasConversion(
                v => v.ToString(),
                v => (SexEnum)Enum.Parse(typeof(SexEnum), v))
            .IsUnicode(false);

        employee.Property(x => x.RoleEnum)
            .HasConversion(
                v => v.ToString(),
                v => (RoleEnum)Enum.Parse(typeof(RoleEnum), v))
            .IsUnicode(false);
        
        var brand = modelBuilder.Entity<Brand>();
        brand.HasKey(x => x.Id);
        brand.Property(x => x.Id)
            .UseIdentityColumn();

        brand.HasMany(x => x.Cars)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId);

        brand.Property(x => x.IsDeleted).HasDefaultValue(0);

        var feature = modelBuilder.Entity<Feature>();
        feature.HasKey(x => x.Id);
        feature.Property(x => x.Id)
            .UseIdentityColumn();

        feature.HasMany(x => x.CarFeatures)
            .WithOne(x => x.Feature)
            .HasForeignKey(x => x.FeatureId);


        var carFeature = modelBuilder.Entity<CarFeature>();
        carFeature.HasKey(x => new { MaXe = x.CarId, MaTinhNang = x.FeatureId });

        var car = modelBuilder.Entity<Car>();
        car.HasKey(x => x.Id);
        car.Property(x => x.Id)
            .UseIdentityColumn();
        
        car.HasMany(x => x.CarPhotoGalleries)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId);
        
        car.HasMany(x => x.CarFeatures)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId);
        
        car.Property(x => x.FuelEnum)
            .HasConversion(
                v => v.ToString(),
                v => (FuelEnum)Enum.Parse(typeof(FuelEnum), v))
            .IsUnicode(false);
        
        car.Property(x => x.TransmissionEnum)
            .HasConversion(
                v => v.ToString(),
                v => (TransmissionEnum)Enum.Parse(typeof(TransmissionEnum), v))
            .IsUnicode(false);

        var follow = modelBuilder.Entity<Follow>();
        follow.HasKey(x => new { x.CarId, x.CustomerId });

        follow.HasOne<Car>(x => x.Car)
            .WithMany(x => x.Follows)
            .HasForeignKey(x => x.CarId);

        follow.HasOne<Customer>(x => x.Customer)
            .WithMany(x => x.Follows)
            .HasForeignKey(x => x.CustomerId);
        
        var rentRequest = modelBuilder.Entity<RentRequest>();
        rentRequest.HasKey(x => x.Id);
        rentRequest.Property(x => x.Id)
            .UseIdentityColumn();
        
        rentRequest.HasOne(x => x.Customer)
            .WithMany(x => x.RentRequests)
            .HasForeignKey(x => x.CustomerId);

        rentRequest.HasOne(x => x.Car)
            .WithMany(x => x.RentRequests)
            .HasForeignKey(x => x.CarId);

        rentRequest.Property(x => x.RentRequestStatusEnum)
            .HasConversion(
                v => v.ToString(),
                v => (RentRequestStatusEnum)Enum.Parse(typeof(RentRequestStatusEnum), v))
            .IsUnicode(false);
        
        rentRequest.Property(x => x.RentalMethod)
            .HasConversion(
                v => v.ToString(),
                v => (RentalMethodEnum)Enum.Parse(typeof(RentalMethodEnum), v))
            .IsUnicode(false);
            
        rentRequest.Property(x => x.TotalPrice).HasPrecision(_sizeDecimal, _sizeDecimalScale);

        rentRequest.HasOne(x => x.Contract)
            .WithOne(x => x.RentRequest)
            .HasForeignKey<Contract>(x => x.RentRequestId);
        
        var surcharge = modelBuilder.Entity<SurCharge>();
        surcharge.HasKey(x => x.Id);
        surcharge.Property(x => x.Id)
            .UseIdentityColumn();
        surcharge.Property(x => x.Price).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        
        surcharge.HasOne(x => x.CarType)
            .WithMany(x => x.Surcharges)
            .HasForeignKey(x => x.CarTypeId);
        
        var carTransferAgreement = modelBuilder.Entity<CarTransferAgreement>();
        carTransferAgreement.HasKey(x => x.Id);
        carTransferAgreement.Property(x => x.Id)
            .UseIdentityColumn();

        carTransferAgreement.HasOne(x => x.Car)
            .WithMany(x => x.CarTransferAgreements)
            .HasForeignKey(x => x.CarId);
        
        carTransferAgreement.HasOne(x => x.Contract)
            .WithMany(x => x.CarTransferAgreements)
            .HasForeignKey(x => x.ContractId);
        
        carTransferAgreement.Property(x => x.CheckInOutEnum)
            .HasConversion(
                v => v.ToString(),
                v => (CheckInOutEnum)Enum.Parse(typeof(CheckInOutEnum), v))
            .IsUnicode(false);
        
        carTransferAgreement.Property(x => x.CreatedAt)
            .HasDefaultValueSql("getdate()");
        
        var contact = modelBuilder.Entity<Contact>();
        contact.HasKey(x => x.Id);
        contact.Property(x => x.Id)
            .UseIdentityColumn();
        
        var damage = modelBuilder.Entity<Damages>();
        damage.HasKey(x => x.Id);
        damage.Property(x => x.Id)
            .UseIdentityColumn();
        
        damage.HasOne(x => x.Car)
            .WithMany(x => x.Damages)
            .HasForeignKey(x => x.CarId);
        
        damage.HasOne(x => x.Contract)
            .WithOne(x => x.Damages)
            .HasForeignKey<Damages>(x => x.ContractId);
        
        damage.Property(x => x.TotalRepairCost).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        
        var receipt = modelBuilder.Entity<Receipt>();
        receipt.HasKey(x => x.Id);
        receipt.Property(x => x.Id)
            .UseIdentityColumn();
        
        receipt.Property(x => x.Type)
            .HasConversion(
                v => v.ToString(),
                v => (ReceiptTypeEnum)Enum.Parse(typeof(ReceiptTypeEnum), v))
            .IsUnicode(false);
        
        receipt.HasOne(x => x.Contract)
            .WithMany(x => x.Receipts)
            .HasForeignKey(x => x.ContractId);
        receipt.Property(x => x.Price).HasPrecision(_sizeDecimal, _sizeDecimalScale);
        base.OnModelCreating(modelBuilder);
    }
}