namespace practica_proiect.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string Venue { get; set; }

        public ICollection<TicketCategoryDto> TicketCategories { get; set; }

    }
}
