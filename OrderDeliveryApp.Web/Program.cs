using Microsoft.EntityFrameworkCore;
using OrderDeliveryApp.Infrastructure.Data;
using OrderDeliveryApp.Core.Interfaces;
using OrderDeliveryApp.Infrastructure.Repositories;
using OrderDeliveryApp.Core.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseNpgsql(connectionString));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var dbContext = services.GetRequiredService<ApplicationDbContext>();
		dbContext.Database.Migrate();
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogInformation("Database migrations applied successfully.");
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while applying database migrations.");
	}
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();