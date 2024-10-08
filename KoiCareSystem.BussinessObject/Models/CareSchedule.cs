using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class CareSchedule
{
    public int Id { get; set; }

    public int PondId { get; set; }

    public string? CareType { get; set; }

    public string? Details { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<CareProperty> CareProperties { get; set; } = new List<CareProperty>();

    public virtual Pond Pond { get; set; } = null!;
}
