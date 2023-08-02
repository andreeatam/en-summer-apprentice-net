using System;
using System.Collections.Generic;

namespace practica_proiect.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
