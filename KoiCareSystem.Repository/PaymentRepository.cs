using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
namespace KoiCareSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        // Create a new payment
        public void CreatePayment(Payment payment)
        {
            PaymentDAO.Instance.AddPayment(payment);
        }

        // Delete a payment by its ID
        public void DeletePayment(int id)
        {
            PaymentDAO.Instance.DeletePayment(id);
        }

        // Retrieve all payments
        public List<Payment> GetAllPayments()
        {
            return PaymentDAO.Instance.GetAllPayments();
        }

        // Retrieve payment history for a specific order
        public List<Payment> GetHistoryPayments(int orderId)
        {
            return PaymentDAO.Instance.GetHistoryPayments(orderId);
        }

        // Retrieve a payment by its ID
        public Payment GetPaymentById(int id)
        {
            return PaymentDAO.Instance.GetPaymentById(id);
        }

        // Retrieve payments by user ID
        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return PaymentDAO.Instance.GetPaymentsByUserId(userId);
        }

        // Update an existing payment
        public void UpdatePayment(Payment payment)
        {
            PaymentDAO.Instance.UpdatePayment(payment);
        }
    }
}