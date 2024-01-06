using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to Shelter Service
    /// </summary>
    public interface IShelterService
    {
        /// <summary>
        /// Retrieves a Shelter by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Shelter</returns>
        Shelter RetrieveShelter(int id);

        /// <summary>
        /// Retrieves a paginated list of all Shelters
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of Shelters</returns>
        PaginatedList<Shelter> RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = ShelterSortingFields.Name, bool sortDesc = false);

        /// <summary>
        /// Adds a new Shelter
        /// </summary>
        /// <param name="shelter"></param>
        Shelter AddShelter(Shelter shelter);

        /// <summary>
        /// Deletes a Shelter from the database
        /// </summary>
        /// <param name="shelter"></param>
        void DeleteShelter(Shelter shelter);

        /// <summary>
        /// Updates a Shelter from the database
        /// </summary>
        /// <param name="shelter"></param>
        void UpdateShelter(Shelter shelter);
    }
}
