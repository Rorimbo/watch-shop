using Core.DB;
using Core.Interfaces;
using Core.Models.Entities;
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
            var id = user.Id;
            return id;
        }
        public async Task<int> LogInAsync(string email, string password)
        {
            var user = await _context.Users
                .Where(user => user.Email == email && user.Password == password)
                .SingleAsync();
            return user.Id;
        }

        public async Task<User> GetUserInfoAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task UpdateUserInfoAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
