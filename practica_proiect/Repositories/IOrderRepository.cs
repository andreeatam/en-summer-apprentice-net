using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Task<Order> GetById(int id);
        Task Add(Order @order);
        Task Update(Order order);
        Task Delete(Order order);

    }
}
