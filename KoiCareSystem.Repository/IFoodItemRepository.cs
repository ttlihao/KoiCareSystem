using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Repository
{
    public interface IFoodItemRepository
    {
        // Define CRUD operations
        List<FoodItem> GetAllFoodItems();
        FoodItem GetFoodItemById(int id);
        void CreateFoodItem(FoodItem foodItem);
        void UpdateFoodItem(FoodItem foodItem);
        void DeleteFoodItem(int id);
    }
}
