using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class IndexModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;

        public IndexModel(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        public IList<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

        public async Task OnGetAsync()
        {
            FoodItems = await _foodItemService.GetAllFoodItemsAsync();
        }
    }
}
