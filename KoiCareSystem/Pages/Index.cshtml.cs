using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPondFeedingService _pondFeedingService;

        public IndexModel(IPondFeedingService pondFeedingService)
        {
            _pondFeedingService = pondFeedingService;
        }
        public IList<PondFeeding> PondFeedings { get; set; } = default;
        public void OnGet()
        {
            PondFeedings = _pondFeedingService.GetListPondFeeding();
        }
    }
}
