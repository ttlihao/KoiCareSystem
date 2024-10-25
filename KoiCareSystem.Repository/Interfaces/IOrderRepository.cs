using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}

