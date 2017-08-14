using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Services.UserData
{
    /// <summary>
    /// Интерфейс для работы с данными пользователей
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// Получает всех пользователей асинхронно
        /// </summary>
        Task<IEnumerable<User>> GetUsersAsync();
        /// <summary>
        /// Создает пользователя асинхронно
        /// </summary>
        /// <returns></returns>
        Task<User> CreateUser();
        /// <summary>
        /// Удаляет пользователя асинхронно
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        Task<bool> DeleteUser(User user);
        /// <summary>
        /// Изменяет пользователя асинхронно
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        Task UpdateUser(User user);
    }
}