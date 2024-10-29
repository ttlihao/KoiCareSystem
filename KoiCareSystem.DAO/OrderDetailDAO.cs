using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.DAO
{
    public class OrderDetailDAO
    {
        // Create a new OrderDetail
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating order detail: {ex.Message}");
            }
        }

        // Retrieve all OrderDetails
        public List<OrderDetail> GetAllOrderDetails()
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.OrderDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order details: {ex.Message}");
                return new List<OrderDetail>();
            }
        }

        // Retrieve OrderDetail by Id
        public OrderDetail GetOrderDetailById(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    return context.OrderDetails.FirstOrDefault(od => od.Id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order detail by id: {ex.Message}");
                return null;
            }
        }

        // Update an existing OrderDetail
        public void UpdateOrderDetail(OrderDetail updatedOrderDetail)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var existingOrderDetail = context.OrderDetails.FirstOrDefault(od => od.Id == updatedOrderDetail.Id);
                    if (existingOrderDetail != null)
                    {
                        existingOrderDetail.OrderId = updatedOrderDetail.OrderId;
                        existingOrderDetail.FoodItemId = updatedOrderDetail.FoodItemId;
                        existingOrderDetail.Price = updatedOrderDetail.Price;
                        existingOrderDetail.Quantity = updatedOrderDetail.Quantity;
                        existingOrderDetail.Total = updatedOrderDetail.Total;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order detail: {ex.Message}");
            }
        }

        // Delete (soft delete) an OrderDetail
        public void DeleteOrderDetail(int id)
        {
            try
            {
                using (var context = new CarekoisystemContext())
                {
                    var orderDetail = context.OrderDetails.FirstOrDefault(od => od.Id == id);
                    if (orderDetail != null)
                    {
                        // If you have a 'Deleted' column, use soft delete logic here
                        context.OrderDetails.Remove(orderDetail);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order detail: {ex.Message}");
            }
        }
    }
}
