using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(int id);
        Task Add(Event @event);
        Task Update(Event @event);
        Task Delete(int id);


        Task<int> GetEventIdByEventName(string eventName);


    }
}
