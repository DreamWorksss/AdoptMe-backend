using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Shelter Repository
    /// </summary>
    public interface IShelterRepository : IGenericRepository<Shelter>
    {
        /// <summary>
        /// Retrieves a paginated list of all shelters
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of shelters</returns>
        PaginatedList<Shelter> RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);

        /// <summary>
        /// Retrieves a list of all shelters without pagination.
        /// </summary>
        /// <returns>List of all shelters.</returns>
        List<Shelter> GetAllShelters();

        /// <summary>
        /// Updates the information of an existing shelter.
        /// </summary>
        /// <param name="shelter">The shelter entity with updated information.</param>
        void UpdateShelter(Shelter shelter);

        /// <summary>
        /// Deletes a shelter by its identifier.
        /// </summary>
        /// <param name="shelterId">The identifier of the shelter to delete.</param>
        void DeleteShelter(int shelterId);

        void BulkInsert(List<Shelter> shelters);
    }
}
