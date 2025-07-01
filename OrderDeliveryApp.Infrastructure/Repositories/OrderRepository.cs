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

	public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return await _context.Orders.FindAsync(id, cancellationToken);
	}

	public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _context.Orders.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(Order order, CancellationToken cancellationToken)
	{
		order.PickupDate = order.PickupDate.ToUniversalTime();
		await _context.Orders.AddAsync(order, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
	}

	public async Task<bool> IsOrderNumberUniqueAsync(int orderNumber, CancellationToken cancellationToken)
	{
		return !await _context.Orders.AnyAsync(o => o.OrderNumber == orderNumber, cancellationToken);
	}
}