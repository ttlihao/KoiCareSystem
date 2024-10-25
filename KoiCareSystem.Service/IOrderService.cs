using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Service
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
