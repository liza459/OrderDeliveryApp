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

	public async Task<IEnumerable<Order>> GetAllOrdersAsync()
	{
		return await _orderRepository.GetAllAsync();
	}

	public async Task<Order> GetOrderByIdAsync(Guid id)
	{
		return await _orderRepository.GetByIdAsync(id);
	}

	public async Task<Order> CreateOrderAsync(Order order)
	{
		int newOrderNumber;
		do
		{
			newOrderNumber = _random.Next(100000, 1000000);
		} while (!await _orderRepository.IsOrderNumberUniqueAsync(newOrderNumber));

		order.OrderNumber = newOrderNumber;
		order.Id = Guid.NewGuid();

		await _orderRepository.AddAsync(order);
		return order;
	}
}