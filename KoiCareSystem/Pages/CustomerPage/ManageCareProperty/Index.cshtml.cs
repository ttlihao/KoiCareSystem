using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManageCareProperty
{
    public class IndexModel : PageModel
    {
        private readonly ICarePropertyService carePropertyService;

        public IndexModel(ICarePropertyService carePropertyService)
        {
            this.carePropertyService = carePropertyService;
        }

        public IList<CareProperty> CareProperty { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CareProperty = await carePropertyService.GetCareProperties();
        }
    }
}
