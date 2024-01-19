using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to AdoptionRequest Repository
    /// </summary>
    public interface IAdoptionRequestRepository : IGenericRepository<AdoptionRequest>
    {
        /// <summary>
        /// Retrieves a paginated list of all adoptionRequests
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of adoptionRequests</returns>
        PaginatedList<AdoptionRequest> RetrieveAdoptionRequests(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all adoptionRequests without pagination.
        /// </summary>
        /// <returns>List of all adoptionRequests.</returns>
        List<AdoptionRequest> GetAllAdoptionRequests();

        /// <summary>
        /// Updates the information of an existing adoptionRequest.
        /// </summary>
        /// <param name="adoptionRequest">The adoptionRequest entity with updated information.</param>
        void UpdateAdoptionRequest(AdoptionRequest adoptionRequest);

        /// <summary>
        /// Deletes a adoptionRequest by its identifier.
        /// </summary>
        /// <param name="adoptionRequestId">The identifier of the adoptionRequest to delete.</param>
        void DeleteAdoptionRequest(AdoptionRequest adoptionRequest);
    }
}
