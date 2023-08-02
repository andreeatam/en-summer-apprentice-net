using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly PracticaDbContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new PracticaDbContext();
        }

        public async Task <IEnumerable<Order>> GetAll()
        {
            var orders = _dbContext.Orders
                .Include(e => e.TicketCategory)
                .ThenInclude(e => e.Event);
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            Order order = await _dbContext.Orders
                .Where(o => o.OrderId == id)
                .Include(e => e.TicketCategory)
                .ThenInclude(e => e.Event)
                .FirstOrDefaultAsync();
            return order;
        }

        public async Task Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public int Add(Order @order)
        {
            throw new NotImplementedException();
        }
    }
}
