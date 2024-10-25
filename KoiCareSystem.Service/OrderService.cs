using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository.Interfaces;

namespace KoiCareSystem.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders() => _orderRepository.GetAllOrders();
        public Order GetOrderById(int id) => _orderRepository.GetOrderById(id);
        public void CreateOrder(Order order) => _orderRepository.CreateOrder(order);
        public void UpdateOrder(Order order) => _orderRepository.UpdateOrder(order);
        public void DeleteOrder(int id) => _orderRepository.DeleteOrder(id);
    }
}

