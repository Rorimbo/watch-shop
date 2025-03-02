
using Core.DB;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        ApplicationContext _context;
        DbSet<User> _dbSet;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<int> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public User GetUserInfo(int id)
        {
            throw new NotImplementedException();
        }

        public int LogIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserInfo(User user)
        {
            throw new NotImplementedException();
        }
    }
}
