using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Animal Repository
    /// </summary>
    public interface IPetRepository : IGenericRepository<Pet>
    {
        /// <summary>
        /// Retrieves a paginated list of all animals
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of animals</returns>
        PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);



























































        PaginatedList<Pet> RetrievePetsByShelter(int shelterId, int page = 0, int pageSize = 15);
    }
}
