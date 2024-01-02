using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to Pet Service
    /// </summary>
    public interface IPetService
    {
        /// <summary>
        /// Retrieves an pet by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pet</returns>
        Pet RetrievePet(int id);

        /// <summary>
        /// Retrieves a paginated list of all pets
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of pets</returns>
        PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false);

        /// <summary>
        /// Adds a new pet
        /// </summary>
        /// <param name="pet"></param>
        void AddPet(Pet pet);

        /// <summary>
        /// Deletes an pet from the database
        /// </summary>
        /// <param name="pet"></param>
        void DeletePet(Pet pet);

        /// <summary>
        /// Updates an pet from the database
        /// </summary>
        /// <param name="pet"></param>
        void UpdatePet(Pet pet);
    }
}
