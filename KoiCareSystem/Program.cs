using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();




builder.Services.AddScoped<ICarePropertyService, CarePropertyService>();
builder.Services.AddScoped<ICareScheduleService, CareScheduleService>();
builder.Services.AddScoped<ICareScheduleRepository, CareScheduleRepository>();
builder.Services.AddScoped<ICarePropertyRepository, CarePropertyRepository>();

builder.Services.AddDbContext<CarekoisystemContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();
