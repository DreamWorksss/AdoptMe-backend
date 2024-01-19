using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository
{
    public class AdoptionRequestRepository : GenericRepository<AdoptionRequest>, IAdoptionRequestRepository
    {
        private readonly AdoptMeDbContext _context;

        public AdoptionRequestRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<AdoptionRequest> RetrieveAdoptionRequests(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var adoptionRequests = _context.AdoptionRequests.AsQueryable();
            adoptionRequests = sortBy switch
            {
                AdoptionRequestSortingFields.Name => sortDesc ? adoptionRequests.OrderByDescending(x => x.Name) : adoptionRequests.OrderBy(x => x.Name),
                _ => adoptionRequests // Default sorting if no valid sortBy field is provided
            };

            var adoptionRequestCount = adoptionRequests.Count();
            return new PaginatedList<AdoptionRequest>
            {
                Entities = adoptionRequests.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = adoptionRequestCount,
                TotalNumberOfPages = (int)Math.Ceiling(adoptionRequestCount / (double)pageSize)
            };
        }

        public List<AdoptionRequest> GetAllAdoptionRequests()
        {
            return _context.AdoptionRequests.ToList();
        }

        public void UpdateAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            _context.Update(adoptionRequest);
            _context.SaveChanges();
        }

        public void DeleteAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Remove(adoptionRequest);
            _context.SaveChanges();
        }
    }
}
