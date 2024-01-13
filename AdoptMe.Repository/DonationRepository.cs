using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        private readonly AdoptMeDbContext _context;

        public DonationRepository(AdoptMeDbContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedList<Donation> RetrieveDonations(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false)
        {
            var donations = _context.Donations.AsQueryable();
            donations = sortBy switch
            {
                DonationSortingFields.UserEmail => sortDesc ? donations.OrderByDescending(x => x.UserEmail) : donations.OrderBy(x => x.UserEmail),
                _ => donations // Default sorting if no valid sortBy field is provided
            };

            var donationCount = donations.Count();
            return new PaginatedList<Donation>
            {
                Entities = donations.Skip(page * pageSize).Take(pageSize).ToList(),
                TotalNumberOfEntities = donationCount,
                TotalNumberOfPages = (int)Math.Ceiling(donationCount / (double)pageSize)
            };
        }

        public List<Donation> GetAllDonations()
        {
            return _context.Donations.ToList();
        }

        public void UpdateDonation(Donation donation)
        {
            _context.Update(donation);
            _context.SaveChanges();
        }

        public void DeleteDonation(Donation donation)
        {
            _context.Donations.Remove(donation);
            _context.SaveChanges();
        }
    }
}
