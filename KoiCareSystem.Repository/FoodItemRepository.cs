using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodItemDAO _foodItemDAO;

        // Constructor with Dependency Injection
        public FoodItemRepository(FoodItemDAO foodItemDAO)
        {
            _foodItemDAO = foodItemDAO;
        }

        // Create a new FoodItem asynchronously
        public async Task CreateFoodItemAsync(FoodItem foodItem)
        {
            await _foodItemDAO.CreateFoodItemAsync(foodItem);
        }

        // Retrieve all FoodItems asynchronously
        public async Task<List<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _foodItemDAO.GetAllFoodItemsAsync();
        }

        // Retrieve a FoodItem by Id asynchronously
        public async Task<FoodItem> GetFoodItemByIdAsync(int id)
        {
            return await _foodItemDAO.GetFoodItemByIdAsync(id);
        }

        // Update a FoodItem asynchronously
        public async Task UpdateFoodItemAsync(FoodItem foodItem)
        {
            await _foodItemDAO.UpdateFoodItemAsync(foodItem);
        }

        // Delete (soft delete) a FoodItem asynchronously
        public async Task DeleteFoodItemAsync(int id)
        {
            await _foodItemDAO.DeleteFoodItemAsync(id);
        }
    }
}
