using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    public interface IUserService
    {
        User RetrieveUser(int id);
        User RetrieveUser(string username, string password);
    }
}
