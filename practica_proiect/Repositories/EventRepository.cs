using Microsoft.EntityFrameworkCore;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly PracticaDbContext _dbContext;

        public EventRepository()
        {
            _dbContext = new PracticaDbContext();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var events = _dbContext.Events
                .Include(e => e.EventType)
                .Include(e => e.Venue);
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

        public async Task Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

    }
}
