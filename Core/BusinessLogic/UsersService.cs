using Core.DB;
using Core.Interfaces;
using Core.Models.DTO;
using Core.Models.Entities;
using Core.Repositories;

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
        public async Task<int> LogInAsync(string email, string password)
        {
            var id = await _usersRepository.LogInAsync(email, password);
            return id;
        }

        public async Task<User> GetUserInfoAsync(int id)
        {
            var user = await _usersRepository.GetUserInfoAsync(id);
            return user;
        }

        public async Task UpdateUserInfoAsync(User user)
        {
            await _usersRepository.UpdateUserInfoAsync(user);
        }
    }
}
