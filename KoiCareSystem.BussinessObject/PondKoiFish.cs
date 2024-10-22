using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class PondKoiFish
{
    public int PondId { get; set; }

    public int KoifishId { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? RemovedDate { get; set; }

    public virtual KoiFish Koifish { get; set; } = null!;

    public virtual Pond Pond { get; set; } = null!;
}
