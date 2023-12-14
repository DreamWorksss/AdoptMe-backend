using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Service.Exceptions;
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

        public void AddShelter(Shelter shelter)
        {
            try
            {
                _shelterRepository.Add(shelter);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error adding shelter", ex);
            }
        }

        public void DeleteShelter(Shelter shelter)
        {
            try
            {
                _shelterRepository.Delete(shelter);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error deleting shelter", ex);
            }
        }

        public Shelter RetrieveShelter(int id)
        {
            try
            {
                var retrievedShelter = _shelterRepository.RetrieveById(id);
                if (retrievedShelter == null)
                {
                    throw new ShelterNotFoundException("Shelter not found");
                }
                return retrievedShelter;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving shelter", ex);
            }
        }

        public PaginatedList<Shelter> RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = ShelterSortingFields.Name, bool sortDesc = false)
        {
            try
            {
                return _shelterRepository.RetrieveShelters(page, pageSize, sortBy, sortDesc);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving shelters", ex);
            }
        }

        public void UpdateShelter(Shelter Shelter)
        {
            try
            {
                _shelterRepository.Update(Shelter);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error updating shelter", ex);
            }
        }
    }
}
