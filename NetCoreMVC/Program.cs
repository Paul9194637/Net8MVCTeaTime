using Microsoft.EntityFrameworkCore;
using NetCoreMVC.DataAccess.Data;
using NetCoreMVC.DataAccess.Repository;
using NetCoreMVC.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;


var builder = WebApplication.CreateBuilder(args);

// For Razor use Localization Language
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources"; // Set the path to  resource files
});

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

// Load configuration from appsettings.json and environment specific file
builder.Configuration .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Set TNS_ADMIN Foler
string tnsFolderName = builder.Configuration["TNS_ADMIN"];
// Get Root Path
string rootPath = builder.Environment.ContentRootPath;
string tnsFileFolder = Path.Combine(rootPath, tnsFolderName);
// Set a EnvironmentVariable for tnsnames.ora
Environment.SetEnvironmentVariable("TNS_ADMIN", tnsFileFolder);

// Register Oracle services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("CST2ConnectionString")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var supportedCultures = new[] { "en", "zh-TW" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures (supportedCultures)
    .AddSupportedUICultures (supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
