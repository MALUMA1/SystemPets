using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using SysPet.Exception;
using SysPet.Extensions;
using SysPet.Models;
using SysPet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Sincronizacion de la libreria de PDF
var context = new CustomAsemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "Agents/libwkhtmltox.dll"));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddScoped<IPdfService<InternamientosViewModel>, PdfService>();

builder.Services.AddScoped<ManageExceptionFilter>();
builder.Services.AddScoped<ToastrService>();

builder.Services.AddScoped(provider =>
{
    return new RoleAuthorizationFilter("Administrador");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Administrador");
    });
    
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = new PathString("/User/Login");
});


builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStatusCodePagesWithReExecute("/Shared/CustomError/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LogIn}");

IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/Windows");

app.Run();
