using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class WaterParameter
{
    public int PondId { get; set; }

    public DateTime CheckDate { get; set; }

    public decimal? Temperature { get; set; }

    public decimal? PH { get; set; }

    public decimal? Co2 { get; set; }

    public decimal? No2 { get; set; }

    public virtual Pond Pond { get; set; } = null!;
}
