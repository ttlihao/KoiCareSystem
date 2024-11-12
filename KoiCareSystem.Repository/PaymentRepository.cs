using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class PaymentRepository
    {
        public List<Payment> GetHistoryPayments(int orderId) => PaymentDAO.Instance.GetHistoryPayments(orderId);

        public List<Payment> GetPaymentsByUserId(int userId) => PaymentDAO.Instance.GetPaymentsByUserId(userId);
    }
}
