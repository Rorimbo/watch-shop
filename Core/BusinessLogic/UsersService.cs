using Core.Interfaces;
using Core.Models;

namespace Core.BusinessLogic
{
    public class UsersService : IUsersService
    {
        public int CreateUser(NewUser user)
        {
            var id = 1;
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
