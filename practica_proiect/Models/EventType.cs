﻿using System;
using System.Collections.Generic;

namespace practica_proiect.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string? Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
