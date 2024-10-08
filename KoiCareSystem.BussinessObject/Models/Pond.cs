using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class Pond
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public bool? Deleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<CareSchedule> CareSchedules { get; set; } = new List<CareSchedule>();

    public virtual ICollection<PondFeeding> PondFeedings { get; set; } = new List<PondFeeding>();

    public virtual ICollection<PondKoiFish> PondKoiFishes { get; set; } = new List<PondKoiFish>();

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}
