using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO;

        // Constructor
        public OrderDetailRepository()
        {
            _orderDetailDAO = new OrderDetailDAO(); // You can use dependency injection here if needed
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDAO.CreateOrderDetail(orderDetail);
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailDAO.GetAllOrderDetails();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _orderDetailDAO.GetOrderDetailById(id);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDAO.UpdateOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int id)
        {
            _orderDetailDAO.DeleteOrderDetail(id);
        }
    }
}
