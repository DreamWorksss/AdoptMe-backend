using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to AdoptionAtDistance Service
    /// </summary>
    public interface IAdoptionAtDistanceService
    {
        /// <summary>
        /// Retrieves an adoption at distance by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AdoptionAtDistance</returns>
        AdoptionAtDistance RetrieveAdoptionAtDistance(int id);

        /// <summary>
        /// Retrieves a paginated list of all adoptions at distance
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of adoptions at distance</returns>
        PaginatedList<AdoptionAtDistance> RetrieveAdoptionsAtDistance(int page = 0, int pageSize = 15, string sortBy = AdoptionAtDistanceSortingFields.UserEmail, bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all adoptions at distance
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Get a list of all adoptions at distance</returns>
        List<AdoptionAtDistance> GetAllAdoptionsAtDistance();

        /// <summary>
        /// Adds a new AdoptionAtDistance
        /// </summary>
        /// <param name="adoptionAtDistance"></param>
        AdoptionAtDistance AddAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance);

        /// <summary>
        /// Deletes an AdoptionAtDistance from the database
        /// </summary>
        /// <param name="adoptionAtDistanceId"></param>
        void DeleteAdoptionAtDistance(int adoptionAtDistanceId);

        /// <summary>
        /// Updates an AdoptionAtDistance from the database
        /// </summary>
        /// <param name="adoptionAtDistance"></param>
        void UpdateAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance);
    }
}
