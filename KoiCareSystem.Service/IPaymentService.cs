using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IPaymentService
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);

        // Thêm phương thức bất đồng bộ
        Task<IList<Payment>> GetAllPaymentsAsync();
        void AddPayment(Payment payment);
    }
}
