using OrderDeliveryApp.Core.Interfaces;
using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Core.Services;

public class OrderService : IOrderService
{
	private readonly IOrderRepository _orderRepository;
	private static readonly Random _random = new Random();

	public OrderService(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
	{
		return await _orderRepository.GetAllAsync(cancellationToken);
	}

	public async Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return await _orderRepository.GetByIdAsync(id, cancellationToken);
	}

	public async Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken)
	{
		int newOrderNumber;
		do
		{
			newOrderNumber = _random.Next(100000, 1000000);
		} while (!await _orderRepository.IsOrderNumberUniqueAsync(newOrderNumber, cancellationToken));

		order.OrderNumber = newOrderNumber;
		order.Id = Guid.NewGuid();

		await _orderRepository.AddAsync(order, cancellationToken);
		return order;
	}
}