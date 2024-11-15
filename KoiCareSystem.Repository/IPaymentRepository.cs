using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task CreatePaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);

        Task<List<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<List<Payment>> GetHistoryPaymentsAsync(int orderId);
    }
}
