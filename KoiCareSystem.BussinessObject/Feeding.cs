using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class Feeding
{
    public int Id { get; set; }

    public int? PondFeedingId { get; set; }

    public string? FoodType { get; set; }

    public decimal? FeedAmount { get; set; }

    public DateTime? FeedingTime { get; set; }

    public virtual ICollection<PondFeeding> PondFeedings { get; set; } = new List<PondFeeding>();
}
