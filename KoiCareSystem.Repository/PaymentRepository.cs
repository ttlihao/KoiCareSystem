using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly PaymentDAO _paymentDAO;

        // Inject PaymentDAO via constructor
        public PaymentRepository(PaymentDAO paymentDAO)
        {
            _paymentDAO = paymentDAO ?? throw new ArgumentNullException(nameof(paymentDAO));
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _paymentDAO.AddPaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentDAO.DeletePaymentAsync(id);
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentDAO.GetAllPaymentsAsync();
        }

        public async Task<List<Payment>> GetHistoryPaymentsAsync(int orderId)
        {
            return await _paymentDAO.GetHistoryPaymentsAsync(orderId);
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentDAO.GetPaymentByIdAsync(id);
        }

        public async Task<List<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _paymentDAO.GetPaymentsByUserIdAsync(userId);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentDAO.UpdatePaymentAsync(payment);
        }
    }
}
