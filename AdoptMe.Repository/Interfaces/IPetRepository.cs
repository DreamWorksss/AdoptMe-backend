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
        
        /// <summary>
        /// Retrieves a list of all pets without pagination.
        /// </summary>
        /// <returns>List of all pets.</returns>
        List<Pet> GetAllPets();

        /// <summary>
        /// Updates the information of an existing pet.
        /// </summary>
        /// <param name="shelter">The pet entity with updated information.</param>
        void UpdatePet(Pet pet);

        /// <summary>
        /// Deletes a pet by its identifier.
        /// </summary>
        /// <param name="petId">The identifier of the pet to delete.</param>
        void DeletePet(int petId);
    }
}
