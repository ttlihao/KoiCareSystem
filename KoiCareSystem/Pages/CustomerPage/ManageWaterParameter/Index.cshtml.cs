using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManageWaterParameter
{
    public class IndexModel : PageModel
    {
        private readonly IWaterParameterService waterParameterService;

        public IndexModel(IWaterParameterService water)
        {
            waterParameterService = water;
        }

        public IList<WaterParameter> WaterParameter { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (waterParameterService.GetListWaterParameters() == null)
            {
                waterParameterService.GetListWaterParameters();
            }
        }
    }
}
