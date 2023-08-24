namespace practica_proiect.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int EventId { get; set; }

        public string EventName { get; set; }

        public long TotalPrice { get; set; }

        public long NumberOfTickets { get; set; }

        public DateTime OrderdAt { get; set; } = DateTime.Now;

        public TicketCategoryDto TicketCategories { get; set; }

        public virtual UserDto Users { get; set; }


    }
}
