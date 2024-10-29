using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.PaymentPage
{
    public class DetailsModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public DetailsModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Order) // Include related data if necessary
                .FirstOrDefaultAsync(m => m.Id == id);

            if (payment == null)
            {
                return NotFound();
            }
            else
            {
                Payment = payment;
            }
            return Page();
        }
    }
}
