using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IServiceProvider serviceProvider)
        {
            _petRepository = serviceProvider.GetRequiredService<IPetRepository>();
        }

        public void AddPet(Pet animal)
        {
            _petRepository.Add(animal);
        }

        public void DeleteAnimal(Pet animal)
        {
            _petRepository.Delete(animal);
        }

        public Pet RetrieveAnimal(int id)
        {
            return _petRepository.RetrieveById(id) ?? throw new Exception("Animal not found"); //TODO: Add proper exception handling
        }

        public PaginatedList<Pet> RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            return _petRepository.RetrievePets(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateAnimal(Pet animal)
        {
            _petRepository.Update(animal);
        }
    }
}
