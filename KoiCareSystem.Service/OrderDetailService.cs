using System.Collections.Generic;
using System.Threading.Tasks;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;

namespace KoiCareSystem.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _orderDetailRepository.GetAllOrderDetailsAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _orderDetailRepository.GetOrderDetailByIdAsync(id);
        }

        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.CreateOrderDetailAsync(orderDetail);
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            await _orderDetailRepository.DeleteOrderDetailAsync(id);
        }
    }
}
