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

        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
        }

        public User RetrieveUser(int id)
        {
            return _userRepository.RetrieveById(id) ?? throw new UserNotFoundException();
        }

        public User RetrieveUser(string username, string password)
        {
            return _userRepository.RetrieveUser(username, password) ?? throw new UserNotFoundException();
        }
    }
}
