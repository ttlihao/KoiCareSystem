using System.Collections.Generic;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;

namespace KoiCareSystem.Service
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;

        // Constructor
        public FoodItemService(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        // Create a new FoodItem
        public void CreateFoodItem(FoodItem foodItem)
        {
            // You can include business logic or validation here before calling the repository
            _foodItemRepository.CreateFoodItem(foodItem);
        }

        // Retrieve all FoodItems
        public List<FoodItem> GetAllFoodItems()
        {
            return _foodItemRepository.GetAllFoodItems();
        }

        // Retrieve a FoodItem by Id
        public FoodItem GetFoodItemById(int id)
        {
            return _foodItemRepository.GetFoodItemById(id);
        }

        // Update a FoodItem
        public void UpdateFoodItem(FoodItem foodItem)
        {
            // You can include business logic or validation here before calling the repository
            _foodItemRepository.UpdateFoodItem(foodItem);
        }

        // Delete (soft delete) a FoodItem
        public void DeleteFoodItem(int id)
        {
            _foodItemRepository.DeleteFoodItem(id);
        }
    }
}
