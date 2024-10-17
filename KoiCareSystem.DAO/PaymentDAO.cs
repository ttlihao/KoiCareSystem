using System;
using System.Collections.Generic;
using System.Linq;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.DAO
{
    public class PaymentDAO
    {
        // Create a new Payment
        public void CreatePayment(Payment payment)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    context.Payments.Add(payment);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating payment: {ex.Message}");
            }
        }

        // Retrieve all Payments
        public List<Payment> GetAllPayments()
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.Payments.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving payments: {ex.Message}");
                return new List<Payment>();
            }
        }

        // Retrieve Payment by Id
        public Payment GetPaymentById(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.Payments.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving payment by id: {ex.Message}");
                return null;
            }
        }

        // Update an existing Payment
        public void UpdatePayment(Payment updatedPayment)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var existingPayment = context.Payments.FirstOrDefault(p => p.Id == updatedPayment.Id);
                    if (existingPayment != null)
                    {
                        existingPayment.OrderId = updatedPayment.OrderId;
                        existingPayment.PaymentDate = updatedPayment.PaymentDate;
                        existingPayment.Total = updatedPayment.Total;
                        existingPayment.Status = updatedPayment.Status;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating payment: {ex.Message}");
            }
        }

        // Delete a Payment (no soft delete logic)
        public void DeletePayment(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var payment = context.Payments.FirstOrDefault(p => p.Id == id);
                    if (payment != null)
                    {
                        context.Payments.Remove(payment);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting payment: {ex.Message}");
            }
        }
    }
}
