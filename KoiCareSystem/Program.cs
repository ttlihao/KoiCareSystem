
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;

using KoiCareSystem.DAO;
using KoiCareSystem.BussinessObject;
using FluentAssertions.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IWaterParameterService, WaterParameterService>();
builder.Services.AddScoped<IWaterParameterRepos, WaterParameterRepos>();

builder.Services.AddScoped<IFeedingService, FeedingService>();
builder.Services.AddScoped<IFeedingRepos, FeedingRepos>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();
builder.Services.AddScoped<IKoiFishService, KoiFishService>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddScoped<IPondService, PondService>();
builder.Services.AddScoped<IPondRepository, PondRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<ICarePropertyRepository, CarePropertyRepository>();
builder.Services.AddScoped<ICarePropertyService, CarePropertyService>();

builder.Services.AddScoped<ICareScheduleRepository, CareScheduleRepository>();
builder.Services.AddScoped<ICareScheduleService, CareScheduleService>();

builder.Services.AddScoped<IPondFeedingRepos, PondFeedingRepos>();
builder.Services.AddScoped<IPondFeedingService, PondFeedingService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<OrderDetailDAO>();
builder.Services.AddScoped<OrderDAO>();
builder.Services.AddScoped<FoodItemDAO>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddScoped<CarekoisystemContext>();
builder.Services.AddScoped<PondDAO>();
builder.Services.AddScoped<OrderDAO>();
builder.Services.AddScoped<CarePropertyDAO>();
builder.Services.AddScoped<CareScheduleDAO>();
builder.Services.AddScoped<FeedingDAO>();
builder.Services.AddScoped<OrderDAO>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});





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
