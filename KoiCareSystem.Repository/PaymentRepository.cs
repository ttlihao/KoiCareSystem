using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDAO _paymentDAO;

        // Constructor
        public PaymentRepository()
        {
            _paymentDAO = new PaymentDAO(); // You can use dependency injection here if needed
        }

        public void CreatePayment(Payment payment)
        {
            _paymentDAO.CreatePayment(payment);
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentDAO.GetAllPayments();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentDAO.GetPaymentById(id);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentDAO.UpdatePayment(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentDAO.DeletePayment(id);
        }
    }
}
