using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.DAO
{
    public class OrderDAO
    {
        private readonly CarekoisystemContext _context;

        public OrderDAO(CarekoisystemContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.Account).Where(o => o.Deleted == false).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.Account).FirstOrDefault(o => o.Id == id && o.Deleted == false);
        }

        public void CreateOrder(Order order)
        {
            order.Deleted = false;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _context.Orders.Find(order.Id);
            if (existingOrder != null && existingOrder.Deleted == false)
            {
                _context.Entry(existingOrder).CurrentValues.SetValues(order);
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Deleted = true;
                _context.SaveChanges();
            }
        }
    }
}
