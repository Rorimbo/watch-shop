using Core.DB;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Core.BusinessLogic
{
    public class UsersService : IUsersService
    {
        ApplicationContext _context;

        private IUsersRepository _usersRepository;
        public UsersService(ApplicationContext context)
        {
            _context = context;
            _usersRepository = new UsersRepository(_context);
        }

        public async Task<int> CreateUserAsync(NewUser user)
        {
            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Password = user.Password,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            var id = await _usersRepository.CreateUserAsync(newUser);
            return id;
        }

        public User GetUserInfo(int id)
        {
            var user = new User();
            return user;
        }

        public int LogIn(string email, string password)
        {
            var id = 1;
            return id;
        }

        public void UpdateUserInfo(User user)
        {
            Console.WriteLine(user);
            return;
        }
    }
}
