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

namespace KoiCareSystem.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly IKoiFishService koiFishService;

        public IList<Account> Account { get; set; } = new List<Account>()!;
        public IList<KoiFish> KoiFish { get; set; } = new List<KoiFish>()!;

        public IndexModel(IAccountService accountService, IKoiFishService koiFishService)
        {
            this.accountService = accountService;
            this.koiFishService = koiFishService;
        }
        public void OnGet()
        {
            LoadUsers();
            LoadKoiFishs();
        }

        // ** USER ** //
        private void LoadUsers()
        {
            Account = accountService.GetAllAccounts();
        }

        private void LoadKoiFishs()
        {
            KoiFish = koiFishService.GetAllKoiFish();
        }
    }
}
