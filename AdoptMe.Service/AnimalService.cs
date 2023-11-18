using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IServiceProvider serviceProvider)
        {
            _animalRepository = serviceProvider.GetRequiredService<IAnimalRepository>();
        }

        public void AddAnimal(Animal animal)
        {
            _animalRepository.Add(animal);
        }

        public void DeleteAnimal(Animal animal)
        {
            _animalRepository.Delete(animal);
        }

        public Animal RetrieveAnimal(int id)
        {
            return _animalRepository.RetrieveById(id) ?? throw new Exception("Animal not found"); //TODO: Add proper exception handling
        }

        public PaginatedList<Animal> RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = AnimalSortingFields.Name, bool sortDesc = false)
        {
            return _animalRepository.RetrieveAnimals(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateAnimal(Animal animal)
        {
            _animalRepository.Update(animal);
        }
    }
}
