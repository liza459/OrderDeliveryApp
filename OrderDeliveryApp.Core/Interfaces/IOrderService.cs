using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Core.Interfaces;

public interface IOrderService
{
	Task<IEnumerable<Order>> GetAllOrdersAsync();
	Task<Order> GetOrderByIdAsync(Guid id);
	Task<Order> CreateOrderAsync(Order order);
}
