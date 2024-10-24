using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.CareSchdulePage
{
    public class IndexModel : PageModel
    {
        private readonly CarePropertyService carePropertyService;

        public IndexModel(CarePropertyService carePropertyService)
        {
            this.carePropertyService = carePropertyService;
        }

        public IList<CareProperty> CareProperty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CareProperty = await carePropertyService.GetCareProperties();
        }
    }
}
