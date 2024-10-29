using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodItemDAO _foodItemDAO;

        // Constructor
        public FoodItemRepository()
        {
            _foodItemDAO = new FoodItemDAO(); // Alternatively, use dependency injection
        }

        // Create a new FoodItem
        public void CreateFoodItem(FoodItem foodItem)
        {
            _foodItemDAO.CreateFoodItem(foodItem);
        }

        // Retrieve all FoodItems
        public List<FoodItem> GetAllFoodItems()
        {
            return _foodItemDAO.GetAllFoodItems();
        }

        // Retrieve a FoodItem by Id
        public FoodItem GetFoodItemById(int id)
        {
            return _foodItemDAO.GetFoodItemById(id);
        }

        // Update a FoodItem
        public void UpdateFoodItem(FoodItem foodItem)
        {
            _foodItemDAO.UpdateFoodItem(foodItem);
        }

        // Delete (soft delete) a FoodItem
        public void DeleteFoodItem(int id)
        {
            _foodItemDAO.DeleteFoodItem(id);
        }
    }
}
