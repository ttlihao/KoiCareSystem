using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFoodItemRepository
{
    Task CreateFoodItemAsync(FoodItem foodItem);
    Task<List<FoodItem>> GetAllFoodItemsAsync();
    Task<FoodItem> GetFoodItemByIdAsync(int id);
    Task UpdateFoodItemAsync(FoodItem foodItem);
    Task DeleteFoodItemAsync(int id);
}
