using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class PaymentDAO
    {
        private CarekoisystemContext dbContext;

        private static PaymentDAO instance;

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        public PaymentDAO()
        {
            dbContext = new CarekoisystemContext();
        }



        public List<Payment> GetHistoryPayments(int orderId)
        {
            return dbContext.Payments
                           .Where(p => p.OrderId == orderId)
                           .Include(p => p.Order)
                           .OrderByDescending(p => p.PaymentDate)
                           .ToList();
        }

        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return dbContext.Payments
                           .Where(p => p.Order.AccountId == userId)
                           .Include(p => p.Order)
                           .OrderByDescending(p => p.PaymentDate)
                           .ToList();
        }
    }
}