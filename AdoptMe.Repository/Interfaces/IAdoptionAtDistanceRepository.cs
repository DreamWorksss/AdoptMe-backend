using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to AdoptAtDistance Repository
    /// </summary>
    public interface IAdoptionAtDistanceRepository : IGenericRepository<AdoptionAtDistance>
    {
        /// <summary>
        /// Retrieves a paginated list of all adoptions at distance
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of adoptions at distance</returns>
        PaginatedList<AdoptionAtDistance> RetrieveAdoptionsAtDistance(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all adoptions at distance without pagination.
        /// </summary>
        /// <returns>List of all adoptions at distance.</returns>
        List<AdoptionAtDistance> GetAllAdoptionsAtDistance();

        /// <summary>
        /// Updates the information of an existing adoption at distance.
        /// </summary>
        /// <param name="adoptionAtDistance">The adoptionAtDistance entity with updated information.</param>
        void UpdateAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance);

        /// <summary>
        /// Deletes an adoption at distance by its identifier.
        /// </summary>
        /// <param name="adoptionAtDistanceId">The identifier of the adoption at distance to delete.</param>
        void DeleteAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance);
    }
}
