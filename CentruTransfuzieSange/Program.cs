using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CentruTransfuzieSange.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>policy.RequireRole("Admin"));
    options.AddPolicy("DoctorPolicy", policy => policy.RequireRole("Doctor","Amin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/MedicalServices");
    options.Conventions.AuthorizeFolder("/Appointments", "DoctorPolicy");
   
    options.Conventions.AllowAnonymousToPage("/MedicalServices/Index");
    options.Conventions.AllowAnonymousToPage("/MedicalServices/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Doctor/Edit", "DoctorPolicy");
    options.Conventions.AuthorizePage("/Members/Details", "DoctorPolicy");

});
builder.Services.AddDbContext<CentruTransfuzieSangeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CentruTransfuzieSangeContext") ?? throw new InvalidOperationException("Connection string 'CentruTransfuzieSangeContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("CentruTransfuzieSangeContext") ?? throw new InvalidOperationException("Connection string 'CentruTransfuzieSangeContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
