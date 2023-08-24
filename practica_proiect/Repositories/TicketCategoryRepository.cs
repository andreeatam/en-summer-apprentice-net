using Microsoft.EntityFrameworkCore;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly NewDbPracticaContext _dbContext;
        public TicketCategoryRepository()
        {
            _dbContext = new NewDbPracticaContext();
        }

        public IEnumerable<TicketCategory> GetAll()
        {
            var tc = _dbContext.TicketCategories;
            return tc;

        }

        public async Task<TicketCategory> GetById(int id)
        {
            var @ticketCateg = await _dbContext.TicketCategories
                .Where(t => t.TicketCategoryId == id)
                .FirstOrDefaultAsync();
            return ticketCateg;
        }

        public async Task AddTicketCategory(TicketCategory ticketCategory)
        {
            _dbContext.TicketCategories.Add(ticketCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
