using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class KoiFish
{
    public int Id { get; set; }

    public string? FishName { get; set; }

    public string? ImagePath { get; set; }

    public int? Age { get; set; }

    public string? Species { get; set; }

    public string? Gender { get; set; }

    public string? HealthStatus { get; set; }

    public string? Origin { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedTime { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<PondKoiFish> PondKoiFishes { get; set; } = new List<PondKoiFish>();
}
