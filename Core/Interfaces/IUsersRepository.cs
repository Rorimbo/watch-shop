using Core.Models;

namespace Core.Interfaces
{
    /// <summary>
    /// Репозиторий, отвечающий за авторизованные пользовательские действия.
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> CreateUserAsync(User user);

        /// <summary>
        /// Авторизация.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int LogIn(string email, string password);

        /// <summary>
        /// Получение информации о пользователе.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserInfo(int id);

        /// <summary>
        /// Обновление информации о пользователе.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserInfo(User user);
    }
}
