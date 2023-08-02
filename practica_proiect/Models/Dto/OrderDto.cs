namespace practica_proiect.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string eventName { get; set; }
        public DateTime? OrderedAt { get; set; }

        public string TicketCategory { get; set; }

        public int? NumberOfTickets { get; set; }
        public int? TotalPrice { get; set; }
    }
}
