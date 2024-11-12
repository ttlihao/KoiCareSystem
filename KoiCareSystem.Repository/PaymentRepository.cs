using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KoiCareSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public void CreatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetHistoryPayments(int orderId) => PaymentDAO.Instance.GetHistoryPayments(orderId);

        public Payment GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByUserId(int userId) => PaymentDAO.Instance.GetPaymentsByUserId(userId);

        public void UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
