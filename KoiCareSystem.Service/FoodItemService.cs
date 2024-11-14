using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class FoodItemService : IFoodItemService
    {
        private readonly CarekoisystemContext _context;

        public FoodItemService(CarekoisystemContext context)
        {
            _context = context;
        }

        // Retrieve all FoodItems that are not soft-deleted
        public async Task<List<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _context.FoodItems
                                 .Where(item => (item.Deleted ?? false) == false)
                                 .ToListAsync();
        }

        // Retrieve a FoodItem by Id, checking it is not soft-deleted
        public async Task<FoodItem> GetFoodItemByIdAsync(int id)
        {
            return await _context.FoodItems
                                 .FirstOrDefaultAsync(item => item.Id == id && (item.Deleted ?? false) == false);
        }

        // Create a new FoodItem
        public async Task CreateFoodItemAsync(FoodItem foodItem)
        {
            if (foodItem == null) return;

            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
        }

        // Update an existing FoodItem
        public async Task UpdateFoodItemAsync(FoodItem foodItem)
        {
            if (foodItem == null) return;

            // Ensure the entity is tracked before updating
            var existingItem = await _context.FoodItems
                                             .FirstOrDefaultAsync(item => item.Id == foodItem.Id && (item.Deleted ?? false) == false);

            if (existingItem != null)
            {
                existingItem.FoodName = foodItem.FoodName;
                existingItem.Price = foodItem.Price;
                existingItem.Category = foodItem.Category;
                existingItem.Type = foodItem.Type;
                existingItem.Quantity = foodItem.Quantity;
                existingItem.Status = foodItem.Status;

                await _context.SaveChangesAsync();
            }
        }

        // Soft delete a FoodItem by setting its Deleted property
        public async Task DeleteFoodItemAsync(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem != null && (foodItem.Deleted ?? false) == false)
            {
                foodItem.Deleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
