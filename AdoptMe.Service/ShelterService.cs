using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.Shelters;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service
{
    public class ShelterService : IShelterService
    {
        private readonly IShelterRepository _shelterRepository;

        public ShelterService(IServiceProvider serviceProvider)
        {
            _shelterRepository = serviceProvider.GetRequiredService<IShelterRepository>();
        }

        public IEnumerable<Shelter> GetAllShelters()
        {
            return _shelterRepository.GetAllShelters();
        }

        public Shelter AddShelter(Shelter shelter)
        {
            return _shelterRepository.Add(shelter);
        }

        public void DeleteShelter(int shelterId)
        {
            _shelterRepository.DeleteShelter(shelterId);
        }

        public Shelter RetrieveShelter(int id)
        {

            var retrievedShelter = _shelterRepository.RetrieveById(id);
            if (retrievedShelter == null)
            {
                throw new ShelterNotFoundException();
            }
            return retrievedShelter;
        }

        public PaginatedList<Shelter> RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = ShelterSortingFields.Name, bool sortDesc = false)
        {
            return _shelterRepository.RetrieveShelters(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateShelter(Shelter Shelter)
        {
            _shelterRepository.UpdateShelter(Shelter);
        }
    }
}
