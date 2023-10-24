using System.Reflection;
using CarRentalManagement;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Settings;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services
    .AddControllersWithViews();

builder.Services
    .AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResource));
    });

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("vi-VN");
    options.AddSupportedUICultures("vi-VN", "en-US");
    options.FallBackToParentUICultures = true;
    options.RequestCultureProviders.Clear();
});


builder.Services.RegistrationService();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(MailSettings.Section));
builder.Services.Configure<CustomSettings>(builder.Configuration.GetSection(CustomSettings.Section));
builder.Services.Configure<CookiesSettings>(builder.Configuration.GetSection(CookiesSettings.Section));
builder.Services.Configure<CompanySettings>(builder.Configuration.GetSection(CompanySettings.Section));

builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!, opt =>
    {
        opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
    }).EnableSensitiveDataLogging());

var cookieSettings = new CookiesSettings();
builder.Configuration.GetSection(CookiesSettings.Section).Bind(cookieSettings);

builder.Services.AddAuthentication(cookieSettings.AuthenticationScheme)
    .AddCookie(cookieSettings.AuthenticationScheme, options =>
    {
        options.LoginPath = cookieSettings.LoginPath;
        options.LogoutPath = cookieSettings.LogoutPath;
        options.AccessDeniedPath = cookieSettings.AccessDeniedPath;
        options.ReturnUrlParameter = cookieSettings.ReturnUrlParameter;
        options.ExpireTimeSpan = TimeSpan.FromDays(cookieSettings.ExpireDay);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(PolicyEnum.ParkingAttendant), policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole(PolicyEnum.ParkingAttendant.Value.Split(','))
            .Build();
    });
    
    options.AddPolicy(nameof(PolicyEnum.SalesRepresentative), policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole(PolicyEnum.SalesRepresentative.Value.Split(','))
            .Build();
    });
    
    options.AddPolicy(nameof(PolicyEnum.Accountant), policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole(PolicyEnum.Accountant.Value.Split(','))
            .Build();
    });
    
    options.AddPolicy(nameof(PolicyEnum.Admin), policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole(PolicyEnum.Admin.Value.Split(','))
            .Build();
    });
    
    options.AddPolicy(nameof(PolicyEnum.All), policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireRole(PolicyEnum.All.Value.Split(','))
            .Build();
    });
    
    
});

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/HandleError");
    app.UseStatusCodePagesWithRedirects("~/Error/HandleError?code={0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    using var serviceScope = app.Services.CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<CarRentalDbContext>();
    await context.Database.MigrateAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization();

app.MapAreaControllerRoute(name: AreaManager.Admin, areaName: AreaManager.Admin, pattern: AreaManager.Admin + "/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();