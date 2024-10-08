using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class FoodItem
{
    public int Id { get; set; }

    public string? FoodName { get; set; }

    public decimal? Price { get; set; }

    public string? Category { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public string? Status { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
