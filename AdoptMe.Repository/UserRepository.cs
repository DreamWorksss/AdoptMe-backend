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
            var userEntity = (from userInfo in _context.Users.Where(x => x.Username == username && x.Password == password)
                              join shelter in _context.Shelters
                              on userInfo.ShelterId equals shelter.Id into shelters
                              from shelter in shelters.DefaultIfEmpty()
                              select new { userInfo, shelter }).FirstOrDefault();

            var user = userEntity?.userInfo;
            if (user != null)
            {
                user.Shelter = userEntity?.shelter;
            }
            return user;
        }

        public User? RetrieveUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
