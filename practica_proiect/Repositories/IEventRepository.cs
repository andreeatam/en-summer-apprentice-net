using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();

        Task<Event> GetById(int id);

        Task Update(Event @event);

        Task Delete(Event @event);

        int Add(Event @event);

    }
}
