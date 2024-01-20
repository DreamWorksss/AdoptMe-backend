using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? RetrieveUser(string username, string password);
    }
}
