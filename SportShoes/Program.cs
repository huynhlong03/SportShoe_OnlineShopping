using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportShoes.Helpers;
using SportShoes.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Connection DB
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 1;

    //// Lockout settings.
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //options.Lockout.MaxFailedAccessAttempts = 5;
    //options.Lockout.AllowedForNewUsers = true;

    //// User settings.
    //options.User.AllowedUserNameCharacters =
    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{

    options.AccessDeniedPath = "/AccessDenied";
    options.LoginPath = new PathString("/Account/Login");
    options.LogoutPath = new PathString("/Account/Logout");
    options.Cookie.Name = "AuthWebapplication";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.SlidingExpiration = true;
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Đăng kí PaypalClient dạng Singleton() - chỉ có 1 instance duy nhất trong toàn ứng dụng
builder.Services.AddSingleton(x => new PaypalClient(
    builder.Configuration["PaypalOptions:AppId"],
    builder.Configuration["PaypalOptions:AppSecret"],
    builder.Configuration["PaypalOptions:Mode"]
    ));

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

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
    {
		endpoints.MapAreaControllerRoute(
			name: "admin",
			areaName: "Admin",
			pattern: "admin/{controller}/{action}/{id?}");

		app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
    });

app.Run();
