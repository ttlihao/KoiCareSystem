using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface IPaymentService
    {
        List<Payment> GetHistoryPayments(int orderId);
        List<Payment> GetPaymentsByUserId(int userId);
    }
}
