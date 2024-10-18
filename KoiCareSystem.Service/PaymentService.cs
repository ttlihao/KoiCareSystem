using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;

namespace KoiCareSystem.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        // Constructor
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void CreatePayment(Payment payment)
        {
            // Add any business logic here
            _paymentRepository.CreatePayment(payment);
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAllPayments();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.GetPaymentById(id);
        }

        public void UpdatePayment(Payment payment)
        {
            // Add any business logic here
            _paymentRepository.UpdatePayment(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentRepository.DeletePayment(id);
        }
    }
}
