using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? FoodItemId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }

    public virtual FoodItem? FoodItem { get; set; }

    public virtual Order Order { get; set; } = null!;
}
