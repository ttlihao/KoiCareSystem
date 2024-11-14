using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace KoiCareSystem.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        // Add a payment to the repository
        public void AddPayment(Payment payment)
        {
            paymentRepository.CreatePayment(payment);
        }

        // Create a new payment (similar to AddPayment; you may want to remove one if redundant)
        public void CreatePayment(Payment payment)
        {
            paymentRepository.CreatePayment(payment);
        }

        // Delete a payment by ID
        public void DeletePayment(int id)
        {
            paymentRepository.DeletePayment(id);
        }

        // Retrieve all payments
        public List<Payment> GetAllPayments()
        {
            return paymentRepository.GetAllPayments();
        }

        // Retrieve all payments asynchronously
        public async Task<IList<Payment>> GetAllPaymentsAsync()
        {
            return await Task.Run(() => paymentRepository.GetAllPayments());
        }

        // Retrieve payment history for a specific order
        public List<Payment> GetHistoryPayments(int orderId)
        {
            return paymentRepository.GetHistoryPayments(orderId);
        }

        // Retrieve a payment by its ID
        public Payment GetPaymentById(int id)
        {
            return paymentRepository.GetPaymentById(id);
        }

        // Retrieve payments by user ID
        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return paymentRepository.GetPaymentsByUserId(userId);
        }

        // Update an existing payment
        public void UpdatePayment(Payment payment)
        {
            paymentRepository.UpdatePayment(payment);
        }
    }
}
