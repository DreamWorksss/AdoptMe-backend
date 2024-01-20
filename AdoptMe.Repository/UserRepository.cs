using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AdoptMeDbContext _context;

        public UserRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public User? RetrieveUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
