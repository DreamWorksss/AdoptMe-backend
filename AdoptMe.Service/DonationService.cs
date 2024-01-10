using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.Donations;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AdoptMe.Service
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IServiceProvider serviceProvider)
        {
            _donationRepository = serviceProvider.GetRequiredService<IDonationRepository>();
        }

        public List<Donation> GetAllDonations()
        {
            return _donationRepository.GetAllDonations();
        }

        public Donation AddDonation(Donation donation)
        {
            return _donationRepository.Add(donation);
        }

        public void DeleteDonation(int donationId)
        {
            _donationRepository.DeleteDonation(donationId);
        }

        public Donation RetrieveDonation(int id)
        {
            var retrievedDonation = _donationRepository.RetrieveById(id);
            if (retrievedDonation == null)
            {
                throw new DonationNotFoundException();
            }
            return retrievedDonation;
        }

        public PaginatedList<Donation> RetrieveDonations(int page = 0, int pageSize = 15, string sortBy = DonationSortingFields.UserEmail, bool sortDesc = false)
        {
            return _donationRepository.RetrieveDonations(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateDonation(Donation donation)
        {
            if (donation == null)
            {
                throw new DonationNotFoundException();
            }
            _donationRepository.UpdateDonation(donation);
        }
    }
}
