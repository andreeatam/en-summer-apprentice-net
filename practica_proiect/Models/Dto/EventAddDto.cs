namespace practica_proiect.Models.Dto
{
    public class EventAddDto
    {
        public int VenueId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
