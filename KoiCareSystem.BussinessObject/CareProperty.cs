using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject;

public partial class CareProperty
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }

    public virtual CareSchedule Schedule { get; set; } = null!;
}
