using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// objeteos auxiliares de coneção
string conn = builder.Configuration.GetConnectionString("MtecDevs");
var version = ServerVersion.AutoDetect(conn);

//serviço de conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseMySql(conn, version)
);
// Serviço de gestão de usuários - Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

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
