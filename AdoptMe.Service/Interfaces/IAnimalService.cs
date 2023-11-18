using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to Animal Service
    /// </summary>
    public interface IAnimalService
    {
        /// <summary>
        /// Retrieves an animal by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Animal</returns>
        Animal RetrieveAnimal(int id);

        /// <summary>
        /// Retrieves a paginated list of all animals
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of animals</returns>
        PaginatedList<Animal> RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = AnimalSortingFields.Name, bool sortDesc = false);

        /// <summary>
        /// Adds a new animal
        /// </summary>
        /// <param name="animal"></param>
        void AddAnimal(Animal animal);

        /// <summary>
        /// Deletes an animal from the database
        /// </summary>
        /// <param name="animal"></param>
        void DeleteAnimal(Animal animal);

        /// <summary>
        /// Updates an animal from the database
        /// </summary>
        /// <param name="animal"></param>
        void UpdateAnimal(Animal animal);
    }
}
