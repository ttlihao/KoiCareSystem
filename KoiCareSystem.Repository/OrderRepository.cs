using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;

        // Constructor injection for OrderDAO
        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        // CRUD methods
        public Task<Order> CreateOrderAsync(Order order) => _orderDAO.CreateOrderAsync(order);

        public Task<Order?> GetOrderByIdAsync(int orderId) => _orderDAO.GetOrderByIdAsync(orderId);

        public Task<List<Order>> GetAllOrdersAsync() => _orderDAO.GetAllOrdersAsync();

        public Task UpdateOrderAsync(Order order) => _orderDAO.UpdateOrderAsync(order);

        public Task DeleteOrderAsync(int orderId) => _orderDAO.DeleteOrderAsync(orderId);

        // New method to get the pending order by account ID
        public Task<Order?> GetPendingOrderByAccountIdAsync(int accountId) => _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
    }
}
