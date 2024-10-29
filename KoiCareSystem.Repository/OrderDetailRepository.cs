using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly CarekoisystemContext _context;

        public OrderDetailRepository(CarekoisystemContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
