using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Core.Interfaces;

public interface IOrderService
{
	Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);
	Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken);
}
