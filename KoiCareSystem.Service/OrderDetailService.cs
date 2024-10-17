using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;

namespace KoiCareSystem.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        // Constructor
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            // Add any business logic here
            _orderDetailRepository.CreateOrderDetail(orderDetail);
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAllOrderDetails();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _orderDetailRepository.GetOrderDetailById(id);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            // Add any business logic here
            _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int id)
        {
            _orderDetailRepository.DeleteOrderDetail(id);
        }
    }
}
