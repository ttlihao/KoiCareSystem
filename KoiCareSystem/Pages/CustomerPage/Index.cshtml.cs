using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly IPondService pondService;
        private readonly IKoiFishService koiFishService;
        private readonly IFeedingService feedingService;
        private readonly IWaterParameterService waterParameterService;
        private readonly ICarePropertyService carePropertyService;
        private readonly ICareScheduleService careScheduleService;

        [BindProperty]
        public IList<Pond> Pond { get; set; } = new List<Pond>()!;
        [BindProperty]
        public IList<KoiFish> KoiFish { get; set; } = new List<KoiFish>()!;
        [BindProperty]
        public IList<Feeding> Feeding { get; set; } = new List<Feeding>()!;
        [BindProperty]
        public IList<WaterParameter> WaterParameter { get; set; } = new List<WaterParameter>();
        [BindProperty]
        public IList<CareProperty> CareProperty { get; set; } = new List<CareProperty>();
        [BindProperty]
        public IList<CareSchedule> CareSchedule { get; set; } = new List<CareSchedule>();


        public IndexModel(IPondService pondService, IKoiFishService koiFishService, IAccountService accountService, IFeedingService feedingService, IWaterParameterService waterParameterService, ICarePropertyService carePropertyService, ICareScheduleService careScheduleService)
        {
            this.pondService = pondService;
            this.koiFishService = koiFishService;
            this.accountService = accountService;
            this.feedingService = feedingService;
            this.waterParameterService = waterParameterService;
            this.carePropertyService = carePropertyService;
            this.careScheduleService = careScheduleService; 
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
            LoadKoiFishs(userId.Value);
            LoadFeedings(userId.Value);
            LoadCareProperty(userId.Value);
            LoadCareSchedules(userId.Value);

            return Page();
        }

        private async void LoadPonds(int userId)
        {
            // Get ponds by account ID
            Pond = await pondService.GetPondsByAccountId(userId);
        }

        private void LoadKoiFishs(int userId)
        {
            // Get koi fish by account ID
            KoiFish = koiFishService.GetKoiFishByAccountId(userId);
        }

        private void LoadFeedings(int userId)
        {
            // Get koi fish by account ID
            Feeding = feedingService.GetFeedingsByAccount(userId);
        }

        private void LoadWaters(int pondId)
        {
            // Get koi fish by account ID
            WaterParameter = waterParameterService.GetListWaterParametersByPond(pondId);
        }
        private void LoadCareSchedules(int userId)
        {
            // Get koi fish by account ID
            CareSchedule = careScheduleService.GetCareScheduleByAccountId(userId);
        }
        private void LoadCareProperty(int userId)
        {
            // Get koi fish by account ID
            CareProperty = carePropertyService.GetCarePropertyByAccountId(userId);
        }
    }
}
