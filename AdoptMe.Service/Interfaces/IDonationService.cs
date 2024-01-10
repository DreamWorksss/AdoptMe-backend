using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to Donation Service
    /// </summary>
    public interface IDonationService
    {
        /// <summary>
        /// Retrieves a Donation by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Donation</returns>
        Donation RetrieveDonation(int id);

        /// <summary>
        /// Retrieves a paginated list of all Donations
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of Donations</returns>
        PaginatedList<Donation> RetrieveDonations(int page = 0, int pageSize = 15, string sortBy = DonationSortingFields.UserEmail, bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all Donations
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Get a list of all Donations</returns>
        List<Donation> GetAllDonations();

        /// <summary>
        /// Adds a new Donation
        /// </summary>
        /// <param name="donation"></param>
        Donation AddDonation(Donation donation);

        /// <summary>
        /// Deletes a Donation from the database
        /// </summary>
        /// <param name="donationId"></param>
        void DeleteDonation(int donationId);

        /// <summary>
        /// Updates a Donation from the database
        /// </summary>
        /// <param name="donation"></param>
        void UpdateDonation(Donation donation);
    }
}
