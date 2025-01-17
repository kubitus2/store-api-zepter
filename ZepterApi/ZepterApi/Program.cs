using Microsoft.EntityFrameworkCore;

using ZepterApi.Models.DB;
using ZepterApi.Models.Seeder;
using ZepterApi.Services;
using ZepterApi.wwwroot.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OrdersDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddScoped<Seeder>();
builder.Services.AddScoped<IStoreService, StoreService>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<OrdersDbContext>();
        var seeder = services.GetRequiredService<Seeder>();

        // Automatyczna migracja i seedowanie
        await context.Database.MigrateAsync();
        await seeder.Seed();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();
