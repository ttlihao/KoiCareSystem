using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail> GetOrderDetailByIdAsync(int id);
        Task CreateOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int id);
    }
}
