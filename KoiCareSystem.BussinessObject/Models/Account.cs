using System;
using System.Collections.Generic;

namespace KoiCareSystem.BussinessObject.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();
}
