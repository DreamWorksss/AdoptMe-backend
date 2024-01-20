using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository
{
    public class AdoptionAtDistanceRepository : GenericRepository<AdoptionAtDistance>, IAdoptionAtDistanceRepository
    {
        private readonly AdoptMeDbContext _context;

        public AdoptionAtDistanceRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<AdoptionAtDistance> RetrieveAdoptionsAtDistance(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var adoptionsAtDistance = _context.AdoptionsAtDistance.AsQueryable();
            adoptionsAtDistance = sortBy switch
            {
                AdoptionAtDistanceSortingFields.UserEmail => sortDesc ? adoptionsAtDistance.OrderByDescending(x => x.UserEmail) : adoptionsAtDistance.OrderBy(x => x.UserEmail),
                _ => adoptionsAtDistance // Default sorting if no valid sortBy field is provided
            };

            var adoptionAtDistanceCount = adoptionsAtDistance.Count();
            return new PaginatedList<AdoptionAtDistance>
            {
                Entities = adoptionsAtDistance.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = adoptionAtDistanceCount,
                TotalNumberOfPages = (int)Math.Ceiling(adoptionAtDistanceCount / (double)pageSize)
            };
        }

        public List<AdoptionAtDistance> GetAllAdoptionsAtDistance()
        {
            return _context.AdoptionsAtDistance.ToList();
        }

        public void UpdateAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance)
        {
            _context.Update(adoptionAtDistance);
            _context.SaveChanges();
            
        }

        public void DeleteAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance)
        {
            _context.AdoptionsAtDistance.Remove(adoptionAtDistance);
            _context.SaveChanges();
        }
    }
}
