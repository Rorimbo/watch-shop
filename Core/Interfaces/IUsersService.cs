using Core.Models.DTO;
using Core.Models.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Сервис, отвечающий за авторизованные пользовательские действия.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> CreateUserAsync(NewUser user);

        /// <summary>
        /// Авторизация.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<int> LogInAsync(string email, string password);

        /// <summary>
        /// Получение информации о пользователе.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserInfoAsync(int id);

        /// <summary>
        /// Обновление информации о пользователе.
        /// </summary>
        /// <param name="user"></param>
        public Task UpdateUserInfoAsync(User user);
    }
}
