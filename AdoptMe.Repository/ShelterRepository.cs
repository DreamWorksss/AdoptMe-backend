using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptMe.Repository
{
    public class ShelterRepository : GenericRepository<Shelter>, IShelterRepository
    {
        private readonly AdoptMeDbContext _context;

        public ShelterRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<Shelter> RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var shelters = _context.Shelters.Include(s => s.Pets).AsQueryable();
            shelters = sortBy switch
            {
                ShelterSortingFields.Name or _ => sortDesc ? shelters.OrderByDescending(x => x.Name) : shelters.OrderBy(x => x.Name)
            };

            var shelterCount = shelters.Count();
            return new PaginatedList<Shelter>
            {
                Entities = shelters.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = shelterCount,
                TotalNumberOfPages = (int)Math.Ceiling(shelterCount / (double)pageSize)
            };
        }
    }
}
