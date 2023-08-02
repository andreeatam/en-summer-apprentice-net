using System;
using System.Collections.Generic;

namespace practica_proiect.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int? TicketCategoryId { get; set; }

    public int? SumOfSoldTickets { get; set; }

    public decimal? TotalValue { get; set; }
}
