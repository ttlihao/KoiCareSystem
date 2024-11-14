using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly IPondService pondService;
        private readonly IKoiFishService koiFishService;
        private readonly IFeedingService feedingService;

        public IList<Pond> Pond { get; set; } = new List<Pond>()!;
        public IList<KoiFish> KoiFish { get; set; } = new List<KoiFish>()!;
        public IList<Feeding> Feeding { get; set; } = new List<Feeding>()!;


        public IndexModel(IPondService pondService, IKoiFishService koiFishService)
        {
            this.pondService = pondService;
            this.koiFishService = koiFishService;
        }

        public IActionResult OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // Redirect to login if user ID is not in session
                return RedirectToPage("/Login");
            }

            // Load ponds and koi fish for the logged-in user
            LoadPonds(userId.Value);
            LoadKoiFishs();

            return Page();
        }

        private void LoadPonds(int userId)
        {
            // Get ponds by account ID
            Pond = pondService.GetPondsByAccountId(userId);
        }

        private void LoadKoiFishs()
        {
            // Get koi fish by account ID
            KoiFish = koiFishService.GetAllKoiFish();
        }

        private void LoadFeedings()
        {
            // Get koi fish by account ID
            Feeding = feedingService.GetListFeeding();
        }
    }
}
