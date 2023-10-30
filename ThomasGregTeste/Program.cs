using Microsoft.EntityFrameworkCore;
using ThomasGreg.App.Configurations;
using ThomasGreg.Business;
using ThomasGreg.Business.Interfaces;
using ThomasGreg.Business.Validacoes;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Repository;
using ThomasGregTeste.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped< ILogradouroService, LogradouroService>();
builder.Services.AddScoped<IClienteService, ClienteService>();


builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteValidacao>();

builder.Services.AddDbContext<ThomasGregDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddAutoMapperSetup();

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
