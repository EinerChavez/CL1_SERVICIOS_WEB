using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PREGUNTA_03_CRUD.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PREGUNTA_03_CRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PREGUNTA_03_CRUDContext") ?? throw new InvalidOperationException("Connection string 'PREGUNTA_03_CRUDContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
