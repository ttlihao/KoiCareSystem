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
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
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
            return GetHistoryPaymentsAsync(orderId).GetAwaiter().GetResult();
        }

        // Retrieve a payment by its ID
        public Payment GetPaymentById(int id)
        {
            return paymentRepository.GetPaymentById(id);
        }

        // Retrieve payments by user ID
        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return GetPaymentsByUserIdAsync(userId).GetAwaiter().GetResult();
        }

        // Async versions of the methods
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdAsync(id);
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));
            await _paymentRepository.CreatePaymentAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));
            await _paymentRepository.UpdatePaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
        }

        public async Task<List<Payment>> GetHistoryPaymentsAsync(int orderId)
        {
            return await _paymentRepository.GetHistoryPaymentsAsync(orderId);
        }

        public async Task<List<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _paymentRepository.GetPaymentsByUserIdAsync(userId);
        }

        // Update an existing payment
        public void UpdatePayment(Payment payment)
        {
            paymentRepository.UpdatePayment(payment);
        }
    }
}
