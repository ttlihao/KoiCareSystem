using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
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

        public async Task<List<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        public async Task<FoodItem> GetFoodItemByIdAsync(int id)
        {
            return await _context.FoodItems.FindAsync(id);
        }

        public async Task CreateFoodItemAsync(FoodItem foodItem)
        {
            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodItemAsync(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodItemAsync(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
