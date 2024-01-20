using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    public interface IUserService
    {
        User RetrieveUser(int id);
        User LoginUser(string username, string password);
        User AddUser(User user);
    }
}
