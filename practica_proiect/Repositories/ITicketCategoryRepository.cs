using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface ITicketCategoryRepository
    {
        IEnumerable<TicketCategory> GetAll();
        Task<TicketCategory> GetById(int id);
        Task AddTicketCategory(TicketCategory ticketCategory);
    }
}
