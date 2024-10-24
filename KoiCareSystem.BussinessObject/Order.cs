using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class Order
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    public string? Receiver { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? Deleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
