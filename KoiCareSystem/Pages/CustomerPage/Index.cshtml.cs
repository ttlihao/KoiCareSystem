using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly IPondService pondService;
        private readonly IKoiFishService koiFishService;

        public IList<Pond> Pond { get; set; } = new List<Pond>()!;
        public IList<KoiFish> KoiFish { get; set; } = new List<KoiFish>()!;

        public IndexModel(IPondService pondService, IKoiFishService koiFishService)
        {
            this.pondService = pondService;
            this.koiFishService = koiFishService;
        }
        public void OnGet()
        {
            LoadPonds();
            LoadKoiFishs();
        }

        // ** USER ** //
        private void LoadPonds()
        {
            Pond = pondService.GetAllPonds();
        }

        private void LoadKoiFishs()
        {
            KoiFish = koiFishService.GetAllKoiFish();
        }
    }
}

