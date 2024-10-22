using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class Payment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Total { get; set; }

    public string? Status { get; set; }

    public virtual Order Order { get; set; } = null!;
}
