using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        Task<User> GetById(int id);

    }
}
