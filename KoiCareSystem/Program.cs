
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;

using KoiCareSystem.DAO;
using KoiCareSystem.Repository;
using KoiCareSystem.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IWaterParameterService, WaterParameterService>();
builder.Services.AddScoped<IWaterParameterRepos, WaterParameterRepos>();

builder.Services.AddScoped<IFeedingService, FeedingService>();
builder.Services.AddScoped<IFeedingRepos, FeedingRepos>();

builder.Services.AddSession();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<CarekoisystemContext>();
builder.Services.AddScoped<AccountDAO>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseSession();

app.Run();
