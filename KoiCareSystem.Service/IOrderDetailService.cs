using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Service
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        void CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int id);
    }
}
