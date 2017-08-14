using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Repository.Repositories;

namespace Services.UserData
{
    /// <summary>
    /// Реализация интерфейса <see cref="IUserDataService"/>
    /// </summary>
    public class UserDataService : IUserDataService
    {
        private readonly IRepository<User> _userRepository;

        public UserDataService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<IEnumerable<User>> GetUsersAsync()
        {
            return Task.Run(() => _userRepository.GetAll());
        }

        public Task<User> CreateUser()
        {
            return Task.Run(() => _userRepository.Create());
        }

        public Task<bool> DeleteUser(User user)
        {
            return Task.Run(() => _userRepository.Delete(user));
        }

        public Task UpdateUser(User user)
        {
            return Task.Run(() => _userRepository.Update(user));
        }
    }
}