using Microsoft.EntityFrameworkCore;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly NewDbPracticaContext _dbContext;

        public EventRepository()
        {
            _dbContext = new NewDbPracticaContext();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events
                .Include(e => e.EventType)
                .Include(e => e.Venue)
                .Include(e => e.TicketCategories);
            return events;

        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events
                .Where(e => e.EventId == id)
                .Include(e => e.EventType)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync();
            return @event;
        }

        public async Task Add(Event @event)
        {
            _dbContext.Events.Add(@event);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _dbContext.Remove(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetEventIdByEventName(string eventName)
        {
            var ev = await _dbContext.Events
                .Where(e => e.Name == eventName)
                .FirstOrDefaultAsync();
            return ev.EventId;
        }

    }
}
