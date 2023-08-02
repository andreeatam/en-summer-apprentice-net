using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface IOrderRepository
    {
        Task <IEnumerable<Order>> GetAll();

        Task<Order> GetById(int id);

        Task Update(Order order);

        Task Delete(Order order);

        int Add(Order @order);

    }
}
