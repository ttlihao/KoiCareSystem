using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.DAO;

public class FoodItemDAO
{
    private readonly CarekoisystemContext _context;

    public FoodItemDAO(CarekoisystemContext context)
    {
        _context = context;
    }

    // Create a new FoodItem
    public async Task CreateFoodItemAsync(FoodItem foodItem)
    {
        await _context.FoodItems.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    // Retrieve all FoodItems (excluding deleted items)
    public async Task<List<FoodItem>> GetAllFoodItemsAsync()
    {
        return await _context.FoodItems
            .Where(item => item.Deleted == false || item.Deleted == null) // Only fetch items that are not marked as deleted
            .ToListAsync();
    }

    // Retrieve a single FoodItem by Id
    public async Task<FoodItem> GetFoodItemByIdAsync(int id)
    {
        return await _context.FoodItems
            .FirstOrDefaultAsync(item => item.Id == id && (item.Deleted == false || item.Deleted == null));
    }

    // Update an existing FoodItem
    public async Task UpdateFoodItemAsync(FoodItem updatedFoodItem)
    {
        var existingItem = await _context.FoodItems.FindAsync(updatedFoodItem.Id);
        if (existingItem != null && (existingItem.Deleted == false || existingItem.Deleted == null))
        {
            existingItem.FoodName = updatedFoodItem.FoodName;
            existingItem.Price = updatedFoodItem.Price;
            existingItem.Category = updatedFoodItem.Category;
            existingItem.Type = updatedFoodItem.Type;
            existingItem.Quantity = updatedFoodItem.Quantity;
            existingItem.Status = updatedFoodItem.Status;

            await _context.SaveChangesAsync();
        }
    }

    // Soft delete a FoodItem
    public async Task DeleteFoodItemAsync(int id)
    {
        var item = await _context.FoodItems.FindAsync(id);
        if (item != null)
        {
            item.Deleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
