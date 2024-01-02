using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Pet Repository
    /// </summary>
    public interface IPetRepository : IGenericRepository<Pet>
    {
        /// <summary>
        /// Retrieves a paginated list of all pets
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of pets</returns>
        PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);
    }
}
