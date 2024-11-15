using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetAllFoodItemsAsync();
        Task<FoodItem> GetFoodItemByIdAsync(int id);
        Task CreateFoodItemAsync(FoodItem foodItem);
        Task UpdateFoodItemAsync(FoodItem foodItem);
        Task DeleteFoodItemAsync(int id);
    }
}
