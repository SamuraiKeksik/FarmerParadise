using Coravel;
using FarmerParadiseTelegramMiniApp.Coravel;
using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().ConfigureApiBehaviorOptions(options => {
    options.SuppressModelStateInvalidFilter = false; // Показывать детали ошибок валидации
}); ;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScheduler();
builder.Services.AddTransient<DailyFieldEventTask>(); //Задача для расписания scheduler

builder.Services.AddDbContext<AppIdentityDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
    options.LoginPath = "/Auth/Login");

var app = builder.Build();
app.UseCors("AllowAll");
app.Services.UseScheduler(schedueler =>
{
    schedueler.Schedule<DailyFieldEventTask>().DailyAtHour(2); //Выполняется в 2 часа по UTC 
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
