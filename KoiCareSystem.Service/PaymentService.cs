using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly CarekoisystemContext _context;

        public PaymentService(CarekoisystemContext context)
        {
            _context = context;
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public async Task<IList<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public Payment GetPaymentById(int id)
        {
            return _context.Payments.Find(id);
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public void CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public void DeletePayment(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }

        public void AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
