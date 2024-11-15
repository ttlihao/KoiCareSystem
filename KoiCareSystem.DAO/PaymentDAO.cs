using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace KoiCareSystem.DAO
{
    public class PaymentDAO
    {
        private CarekoisystemContext dbContext;

        private static PaymentDAO instance;

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        private PaymentDAO()
        {
            dbContext = new CarekoisystemContext();
        }

        // Retrieve payment history for a specific order
        public List<Payment> GetHistoryPayments(int orderId)
        {
            return dbContext.Payments
                           .Where(p => p.OrderId == orderId)
                           .Include(p => p.Order)
                           .OrderByDescending(p => p.PaymentDate)
                           .ToList();
        }

        // Retrieve payments by user ID
        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return dbContext.Payments
                           .Where(p => p.Order.AccountId == userId)
                           .Include(p => p.Order)
                           .OrderByDescending(p => p.PaymentDate)
                           .ToList();
        }

        // Add a new payment
        public void AddPayment(Payment payment)
        {
            dbContext.Payments.Add(payment);
            dbContext.SaveChanges();
        }

        // Update an existing payment
        public void UpdatePayment(Payment payment)
        {
            var existingPayment = dbContext.Payments.Find(payment.Id);
            if (existingPayment != null)
            {
                existingPayment.OrderId = payment.OrderId;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.Total = payment.Total;
                existingPayment.Status = payment.Status;
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Payment not found.");
            }
        }

        // Delete a payment by ID
        public void DeletePayment(int paymentId)
        {
            var payment = dbContext.Payments.Find(paymentId);
            if (payment != null)
            {
                dbContext.Payments.Remove(payment);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Payment not found.");
            }
        }
        public List<Payment> GetAllPayments()
        {
            return dbContext.Payments
                            .Include(p => p.Order)
                            .OrderByDescending(p => p.PaymentDate)
                            .ToList();
        }

        // Retrieve a payment by ID
        public Payment GetPaymentById(int id)
        {
            return dbContext.Payments
                            .Include(p => p.Order)
                            .FirstOrDefault(p => p.Id == id);
        }
    }
}