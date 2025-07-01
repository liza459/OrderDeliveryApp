using Microsoft.EntityFrameworkCore;
using OrderDeliveryApp.Core.Interfaces;
using OrderDeliveryApp.Core.Models;
using OrderDeliveryApp.Infrastructure.Data;

namespace OrderDeliveryApp.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly ApplicationDbContext _context;		

	public OrderRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Order> GetByIdAsync(Guid id)
	{
		return await _context.Orders.FindAsync(id);
	}

	public async Task<IEnumerable<Order>> GetAllAsync()
	{
		return await _context.Orders.ToListAsync();
	}

	public async Task AddAsync(Order order)
	{
		order.PickupDate = order.PickupDate.ToUniversalTime();
		await _context.Orders.AddAsync(order);
		await _context.SaveChangesAsync();
	}

	public async Task<bool> IsOrderNumberUniqueAsync(int orderNumber)
	{
		return !await _context.Orders.AnyAsync(o => o.OrderNumber == orderNumber);
	}
}