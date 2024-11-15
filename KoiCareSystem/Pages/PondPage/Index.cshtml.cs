using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.PondPage
{
    public class IndexModel : PageModel
    {
        private readonly IPondService pondService;

        public IndexModel(IPondService pondService)
        {
            this.pondService = pondService;
        }

        public IList<Pond> Pond { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pond = pondService.GetAllPonds();
        }
    }
}
