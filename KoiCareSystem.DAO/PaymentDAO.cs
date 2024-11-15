using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class PaymentDAO
    {
        private readonly CarekoisystemContext _dbContext;

        // Constructor with dependency injection for dbContext
        public PaymentDAO(CarekoisystemContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Retrieve payment history for a specific order
        public async Task<List<Payment>> GetHistoryPaymentsAsync(int orderId)
        {
            return await _dbContext.Payments
                                    .Where(p => p.OrderId == orderId)
                                    .Include(p => p.Order)
                                    .OrderByDescending(p => p.PaymentDate)
                                    .ToListAsync();
        }

        // Retrieve payments by user ID
        public async Task<List<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _dbContext.Payments
                                    .Where(p => p.Order.AccountId == userId)
                                    .Include(p => p.Order)
                                    .OrderByDescending(p => p.PaymentDate)
                                    .ToListAsync();
        }

        // Add a new payment
        public async Task AddPaymentAsync(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
        }

        // Update an existing payment
        public async Task UpdatePaymentAsync(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            var existingPayment = await _dbContext.Payments.FindAsync(payment.Id);
            if (existingPayment != null)
            {
                existingPayment.OrderId = payment.OrderId;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.Total = payment.Total;
                existingPayment.Status = payment.Status;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Payment not found.");
            }
        }

        // Delete a payment by ID
        public async Task DeletePaymentAsync(int paymentId)
        {
            var payment = await _dbContext.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Payment not found.");
            }
        }

        // Retrieve all payments
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _dbContext.Payments
                                    .Include(p => p.Order)
                                    .OrderByDescending(p => p.PaymentDate)
                                    .ToListAsync();
        }

        // Retrieve a payment by ID
        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            var payment = await _dbContext.Payments
                                           .Include(p => p.Order)
                                           .FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null)
            {
                throw new KeyNotFoundException("Payment not found.");
            }
            return payment;
        }
    }
}
