using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.Pets;
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

        public Pet AddPet(Pet animal)
        {
            return _petRepository.Add(animal);
        }

        public void DeleteAnimal(int petId)
        {
            _petRepository.DeletePet(petId);
        }

        public Pet RetrievePet(int id)
        {
            return _petRepository.RetrieveById(id) ?? throw new PetNotFoundException();
        }

        public Pet RetrievePetWithRequests(int id)
        {
            return _petRepository.RetrievePetWithRequests(id) ?? throw new PetNotFoundException();
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }

        public PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            return _petRepository.RetrievePets(page, pageSize, sortBy, sortDesc);
        }

        public PaginatedList<Pet> RetrievePetsByShelter(int shelterId, int page = 0, int pageSize = 15)
        {
            return _petRepository.RetrievePetsByShelter(shelterId, page, pageSize);
        }

        public void UpdateAnimal(Pet animal)
        {
            _petRepository.UpdatePet(animal);
        }

        public void AcceptPetAdoption(int id)
        {
            _petRepository.AcceptPetAdoption(id);
        }
    }
}
