using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.DAO
{
    public class FoodItemDAO
    {
        // Create (Insert) a new FoodItem
        public void CreateFoodItem(FoodItem foodItem)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    context.FoodItems.Add(foodItem);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating food item: {ex.Message}");
            }
        }

        // Read (Retrieve) all FoodItems
        public List<FoodItem> GetAllFoodItems()
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.FoodItems.Where(item => item.Deleted == false).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving food items: {ex.Message}");
                return new List<FoodItem>();
            }
        }

        // Read (Retrieve) a single FoodItem by Id
        public FoodItem GetFoodItemById(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.FoodItems.FirstOrDefault(item => item.Id == id && item.Deleted == false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving food item by id: {ex.Message}");
                return null;
            }
        }

        // Update an existing FoodItem
        public void UpdateFoodItem(FoodItem updatedFoodItem)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var existingItem = context.FoodItems.FirstOrDefault(item => item.Id == updatedFoodItem.Id);
                    if (existingItem != null && existingItem.Deleted == false)
                    {
                        existingItem.FoodName = updatedFoodItem.FoodName;
                        existingItem.Price = updatedFoodItem.Price;
                        existingItem.Category = updatedFoodItem.Category;
                        existingItem.Type = updatedFoodItem.Type;
                        existingItem.Quantity = updatedFoodItem.Quantity;
                        existingItem.Status = updatedFoodItem.Status;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating food item: {ex.Message}");
            }
        }

        // Soft delete (Mark as deleted) a FoodItem
        public void DeleteFoodItem(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var item = context.FoodItems.FirstOrDefault(f => f.Id == id);
                    if (item != null)
                    {
                        item.Deleted = true;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting food item: {ex.Message}");
            }
        }
    }
}
