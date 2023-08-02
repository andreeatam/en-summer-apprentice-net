using System;
using System.Collections.Generic;

namespace practica_proiect.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? TicketCategoryId { get; set; }

    public DateTime? OrderedAt { get; set; }

    public float? NumberOfTickets { get; set; }

    public float? TotalPrice { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; } = null!;

    public virtual User? User { get; set; } = null!;
}
