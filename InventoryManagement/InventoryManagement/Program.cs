using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Contracts;
using System;
using InventoryManagement.Models;
using InventoryManagement.Services;

var builder = WebApplication.CreateBuilder(args);

//register dbcontext untuk EF
builder.Services.AddDbContext<InventoryDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDB"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddScoped<IProducts, ProductsService>();
builder.Services.AddScoped<ITransactions, TransactionsService>();
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
