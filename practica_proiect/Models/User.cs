﻿using System;
using System.Collections.Generic;

namespace practica_proiect.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
