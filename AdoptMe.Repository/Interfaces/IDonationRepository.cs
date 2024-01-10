using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Donation Repository
    /// </summary>
    public interface IDonationRepository : IGenericRepository<Donation>
    {
        /// <summary>
        /// Retrieves a paginated list of all donations
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of donations</returns>
        PaginatedList<Donation> RetrieveDonations(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all donations without pagination.
        /// </summary>
        /// <returns>List of all donations.</returns>
        List<Donation> GetAllDonations();

        /// <summary>
        /// Updates the information of an existing donation.
        /// </summary>
        /// <param name="donation">The donation entity with updated information.</param>
        void UpdateDonation(Donation donation);

        /// <summary>
        /// Deletes a donation by its identifier.
        /// </summary>
        /// <param name="donationId">The identifier of the donation to delete.</param>
        void DeleteDonation(int donationId);
    }
}
