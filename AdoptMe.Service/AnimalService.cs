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

        public void AddPet(Pet pet)
        {
            _petRepository.Add(pet);
        }

        public void DeletePet(Pet pet)
        {
            _petRepository.Delete(pet);
        }

        public Pet RetrievePet(int id)
        {
            return _petRepository.RetrieveById(id) ?? throw new Exception("Pet not found"); //TODO: Add proper exception handling
        }

        public PaginatedList<Pet> RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            return _petRepository.RetrievePets(page, pageSize, sortBy, sortDesc);
        }

        public void UpdatePet(Pet pet)
        {
            _petRepository.Update(pet);
        }
    }
}
