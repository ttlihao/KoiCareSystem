﻿using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class EditModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;

        public EditModel(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodItem = await _foodItemService.GetFoodItemByIdAsync(id.Value);

            if (FoodItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _foodItemService.UpdateFoodItemAsync(FoodItem);
            return RedirectToPage("./Index");
        }
    }
}
