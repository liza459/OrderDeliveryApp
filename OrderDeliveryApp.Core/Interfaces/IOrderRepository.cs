using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Core.Interfaces;

public interface IOrderRepository
{
	Task<Order> GetByIdAsync(Guid id);
	Task<IEnumerable<Order>> GetAllAsync();
	Task AddAsync(Order order);
	Task<bool> IsOrderNumberUniqueAsync(int orderNumber);
}
