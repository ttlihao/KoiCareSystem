using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class PaymentService : IPaymentService
    {

        private IPaymentRepository paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public void AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

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

        public Task<IList<Payment>> GetAllPaymentsAsync()
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetHistoryPayments(int orderId)
        {
            return paymentRepository.GetHistoryPayments(orderId);
        }

        public Payment GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return paymentRepository.GetPaymentsByUserId(userId);
        }

        public void UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
