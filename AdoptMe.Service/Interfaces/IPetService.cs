﻿using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    /// <summary>
    /// Provides access to Animal Service
    /// </summary>
    public interface IPetService
    {
        /// <summary>
        /// Retrieves an animal by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Animal</returns>
        Pet RetrievePet(int id);

        /// <summary>
        /// Retrieves a paginated list of all animals
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>Paginated list of animals</returns>
        PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false);

        PaginatedList<Pet> RetrievePetsByShelter(int filterby, int page = 0, int pageSize = 15);

        /// <summary>
        /// Adds a new animal
        /// </summary>
        /// <param name="animal"></param>
        Pet AddPet(Pet animal);

        /// <summary>
        /// Deletes an animal from the database
        /// </summary>
        /// <param name="animal"></param>
        void DeleteAnimal(Pet animal);

        /// <summary>
        /// Updates an animal from the database
        /// </summary>
        /// <param name="animal"></param>
        void UpdateAnimal(Pet animal);
    }
}
