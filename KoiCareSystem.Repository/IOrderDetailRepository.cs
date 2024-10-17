using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        void CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int id);
    }
}
