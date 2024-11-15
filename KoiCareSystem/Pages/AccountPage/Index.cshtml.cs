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
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly IKoiFishService koiFishService;
        private readonly IFoodItemService foodItemService;

        public IList<Account> Account { get; set; } = new List<Account>()!;
        public IList<KoiFish> KoiFish { get; set; } = new List<KoiFish>()!;
        public IList<FoodItem> FoodItems { get; set; } = new List<FoodItem>()!;

        public IndexModel(IAccountService accountService, IKoiFishService koiFishService, IFoodItemService foodItemService)
        {
            this.accountService = accountService;
            this.koiFishService = koiFishService;
            this.foodItemService = foodItemService;
        }
        public void OnGet()
        {
            LoadUsers();
            LoadKoiFishs();
            LoadFoodItems();
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
        private async void LoadFoodItems()
        {
            FoodItems = await foodItemService.GetAllFoodItemsAsync();

        }
    }
}
