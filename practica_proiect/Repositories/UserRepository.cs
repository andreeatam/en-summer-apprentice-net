using Microsoft.EntityFrameworkCore;
using practica_proiect.Models;

namespace practica_proiect.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NewDbPracticaContext _dbContext;

        public UserRepository()
        {
            _dbContext = new NewDbPracticaContext();
        }

        public IEnumerable<User> GetAll()
        {
            var @user = _dbContext.Users;
            return @user;

        }

        public async Task<User> GetById(int id)
        {
            var @user = await _dbContext.Users
                .Where(u => u.UserId == id)
                .FirstOrDefaultAsync();
            return @user;
        }
    }
}
