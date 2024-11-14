using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class PondFeeding
{
    public int? Id { get; set; }

    public int? PondId { get; set; }

    public int? FeedingId { get; set; }

    public DateTime? FeedingDate { get; set; }

    public virtual Feeding? Feeding { get; set; } = null!;

    public virtual Pond? Pond { get; set; } = null!;
}
