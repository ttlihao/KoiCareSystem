using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IPaymentService
    {
        List<Payment> GetHistoryPayments(int orderId);
        List<Payment> GetPaymentsByUserId(int userId);
    }
}
