using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly NewDbPracticaContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new NewDbPracticaContext();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.TicketCategory)
                .ThenInclude(e=> e.Event)
                .Include(o => o.TicketCategory);
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order= await _dbContext.Orders
                .Where(o => o.OrderId == id)
                .Include(e => e.TicketCategory)
                .ThenInclude(e => e.Event)
                .ThenInclude(e => e.Venue)
                .FirstOrDefaultAsync();
            return order;
        }

        public async Task Add(Order @order)
        {
            _dbContext.Orders.Add(@order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _dbContext.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

    }
}
