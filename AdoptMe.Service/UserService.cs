using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.Users;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IShelterRepository _shelterRepository;

        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            _shelterRepository = serviceProvider.GetRequiredService<IShelterRepository>();
        }

        public User RetrieveUser(int id)
        {
            return _userRepository.RetrieveById(id) ?? throw new UserNotFoundException();
        }

        public User LoginUser(string username, string password)
        {
            return _userRepository.RetrieveUser(username, password) ?? throw new UserNotFoundException("Login failed!");
        }

        public User AddUser(User user)
        {
            Shelter? shelter = null;
            if (_userRepository.RetrieveUser(user.Username) != null)
            {
                throw new UserAlreadyExistsException();
            }
            if (user.ShelterId.HasValue && user.ShelterId != 0)
            {
                shelter = _shelterRepository.RetrieveById(user.ShelterId.Value);
            }
            else
            {
                user.ShelterId = null;
            }
            user.Shelter = shelter;
            user.Hash = Guid.NewGuid().ToString();
            return _userRepository.Add(user);
        }
    }
}
