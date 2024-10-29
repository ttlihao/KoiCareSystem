﻿using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
    }
}