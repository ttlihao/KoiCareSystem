using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiCareSystem.BussinessObject;

public partial class KoiFish
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Fish Name field is required.")]
    public string? FishName { get; set; }

    public string? ImagePath { get; set; }

    [Range(1, 50, ErrorMessage = "Age must be a positive integer less than 100.")]
    public int? Age { get; set; }
    [Range(1, 20, ErrorMessage = "Species must be a positive integer less than 100.")]
    public string? Species { get; set; }

    [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'.")]
    public string? Gender { get; set; }

    public string? HealthStatus { get; set; }

    public string? Origin { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedTime { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<PondKoiFish> PondKoiFishes { get; set; } = new List<PondKoiFish>();
}
