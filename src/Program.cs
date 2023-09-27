using System.Reflection;
using CarRentalManagement;
using CarRentalManagement.Data;
using CarRentalManagement.Models.Settings;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }).EnableSensitiveDataLogging());

builder.Services.RegistrationService();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(MailSettings.Section));
builder.Services.Configure<CustomSettings>(builder.Configuration.GetSection(CustomSettings.Section));
builder.Services.Configure<CookiesSettings>(builder.Configuration.GetSection(CookiesSettings.Section));
builder.Services.Configure<CompanySettings>(builder.Configuration.GetSection(CompanySettings.Section));

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

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
    options.ListenAnyIP(7218, listenOptions =>
    {
        listenOptions.UseHttps();
    });
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
    options.Limits.MaxConcurrentConnections = 100;
});

var app = builder.Build();

EntityFrameworkProfiler.Initialize();

Log.Logger = new LoggerConfiguration()
    .CreateLogger();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(name: AreaManager.Admin, areaName: AreaManager.Admin, pattern: AreaManager.Admin + "/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();