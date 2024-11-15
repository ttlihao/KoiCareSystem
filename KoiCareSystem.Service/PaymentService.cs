using KoiCareSystem.BussinessObject;
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
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }

        public List<Payment> GetAllPayments()
        {
            return GetAllPaymentsAsync().GetAwaiter().GetResult();
        }

        public Payment GetPaymentById(int id)
        {
            return GetPaymentByIdAsync(id).GetAwaiter().GetResult();
        }

        public void CreatePayment(Payment payment)
        {
            CreatePaymentAsync(payment).GetAwaiter().GetResult();
        }

        public void UpdatePayment(Payment payment)
        {
            UpdatePaymentAsync(payment).GetAwaiter().GetResult();
        }

        public void DeletePayment(int id)
        {
            DeletePaymentAsync(id).GetAwaiter().GetResult();
        }

        public List<Payment> GetHistoryPayments(int orderId)
        {
            return GetHistoryPaymentsAsync(orderId).GetAwaiter().GetResult();
        }

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
    }
}
