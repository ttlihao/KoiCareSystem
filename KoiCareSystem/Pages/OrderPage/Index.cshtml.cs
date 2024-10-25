using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public IndexModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Account).ToListAsync();
        }
    }
}
