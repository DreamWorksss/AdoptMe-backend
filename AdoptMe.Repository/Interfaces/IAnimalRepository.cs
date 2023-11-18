using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Animal Repository
    /// </summary>
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        /// <summary>
        /// Retrieves a paginated list of all animals
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of animals</returns>
        PaginatedList<Animal> RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = "", bool sortDesc = false);
    }
}
