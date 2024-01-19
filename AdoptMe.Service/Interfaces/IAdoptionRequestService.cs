using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to AdoptionRequest Service
    /// </summary>
    public interface IAdoptionRequestService
    {
        /// <summary>
        /// Retrieves a AdoptionRequest by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AdoptionRequest</returns>
        AdoptionRequest RetrieveAdoptionRequest(int id);

        /// <summary>
        /// Retrieves a paginated list of all AdoptionRequests
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of AdoptionRequests</returns>
        PaginatedList<AdoptionRequest> RetrieveAdoptionRequests(int page = 0, int pageSize = 15, string sortBy = AdoptionRequestSortingFields.Name, bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all AdoptionRequests
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Get a list of all AdoptionRequests</returns>
        List<AdoptionRequest> GetAllAdoptionRequests();

        /// <summary>
        /// Adds a new AdoptionRequest
        /// </summary>
        /// <param name="adoptionRequest"></param>
        AdoptionRequest AddAdoptionRequest(AdoptionRequest adoptionRequest);

        /// <summary>
        /// Deletes a AdoptionRequest from the database
        /// </summary>
        /// <param name="adoptionRequestId"></param>
        void DeleteAdoptionRequest(int adoptionRequestId);

        /// <summary>
        /// Updates a AdoptionRequest from the database
        /// </summary>
        /// <param name="adoptionRequest"></param>
        void UpdateAdoptionRequest(AdoptionRequest adoptionRequest);
    }
}
