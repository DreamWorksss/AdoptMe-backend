using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IEnumerable<Shelter> GetAllShelters();
        void UpdateShelter(Shelter shelter);
        void DeleteShelter(int shelterId);
    }
}
