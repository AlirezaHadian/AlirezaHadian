using AlirezaHadian;
using AlirezaHadian.Data;
using AlirezaHadian.Middleware;
using AlirezaHadian.Models;
using DeviceDetectorNET.Parser.Device;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using WebMarkupMin.AspNetCore6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DatabaseConnection")
    ));
builder.Services.AddWebMarkupMin(options =>
{
    options.AllowMinificationInDevelopmentEnvironment = true;
    options.AllowCompressionInDevelopmentEnvironment = true;
})
    .AddHtmlMinification()
    .AddHttpCompression()
    .AddXmlMinification();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseWebMarkupMin();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseSession();

app.UseMiddleware<Middleware>();

app.MapRazorPages();
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
