using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Core.Interfaces;

public interface IOrderRepository
{
	Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);
	Task AddAsync(Order order, CancellationToken cancellationToken);
	Task<bool> IsOrderNumberUniqueAsync(int orderNumber, CancellationToken cancellationToken);
}