using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;

namespace KoiCareSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public List<Order> GetAllOrders() => _orderDAO.GetAllOrders();
        public Order GetOrderById(int id) => _orderDAO.GetOrderById(id);
        public void CreateOrder(Order order) => _orderDAO.CreateOrder(order);
        public void UpdateOrder(Order order) => _orderDAO.UpdateOrder(order);
        public void DeleteOrder(int id) => _orderDAO.DeleteOrder(id);
    }
}

