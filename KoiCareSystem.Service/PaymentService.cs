using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service.Interfaces;
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
        public List<Payment> GetHistoryPayments(int orderId)
        {
            return paymentRepository.GetHistoryPayments(orderId);
        }
        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return paymentRepository.GetPaymentsByUserId(userId);
        }
    }
}
