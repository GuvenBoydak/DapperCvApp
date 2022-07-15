using Autofac;
using Autofac.Extensions.DependencyInjection;
using DapperCvApp.Business;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AppUserPasswordDtoValidator>());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new ServiceModule()));


//CustomCookieAuthentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    //tarayıcı tarafından document.cookie yazıldıgında iligili yere erişim kapatıyoruz.
    opt.Cookie.HttpOnly = true;
    opt.Cookie.Name = "CvAppCookie";
    opt.Cookie.SameSite = SameSiteMode.Strict;  //Diger web sayafalarına cookie kullanımı kapatıyoruz.
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//Https ve Http  de çalişabilir.
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);//Kullanıcı bilgileri 30 gün saklanır.
    opt.LoginPath = new PathString("/Auth/Login");//Hatalı giriş işleminde yönlendiricegimiz sayfayı belirliyoruz.
});

builder.Services.AddAutoMapper(typeof(MapProfile));

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
