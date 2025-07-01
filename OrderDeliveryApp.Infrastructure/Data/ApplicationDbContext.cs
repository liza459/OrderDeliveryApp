using Microsoft.EntityFrameworkCore;
using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	public DbSet<Order> Orders { get; set; }
}
