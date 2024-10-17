using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Service
{
    public interface IFoodItemService
    {
        List<FoodItem> GetAllFoodItems();
        FoodItem GetFoodItemById(int id);
        void CreateFoodItem(FoodItem foodItem);
        void UpdateFoodItem(FoodItem foodItem);
        void DeleteFoodItem(int id);
    }
}
