using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.AdoptionsAtDistance;
using AdoptMe.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AdoptMe.Service
{
    public class AdoptionAtDistanceService : IAdoptionAtDistanceService
    {
        private readonly IAdoptionAtDistanceRepository _adoptionAtDistanceRepository;

        public AdoptionAtDistanceService(IServiceProvider serviceProvider)
        {
            _adoptionAtDistanceRepository = serviceProvider.GetRequiredService<IAdoptionAtDistanceRepository>();
        }

        public List<AdoptionAtDistance> GetAllAdoptionsAtDistance()
        {
            return _adoptionAtDistanceRepository.GetAllAdoptionsAtDistance();
        }

        public AdoptionAtDistance AddAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance)
        {
            return _adoptionAtDistanceRepository.Add(adoptionAtDistance);
        }

        public void DeleteAdoptionAtDistance(int adoptionAtDistanceId)
        {
            var adoptionAtDistance = _adoptionAtDistanceRepository.RetrieveById(adoptionAtDistanceId);
            if (adoptionAtDistance != null)
            {
                _adoptionAtDistanceRepository.DeleteAdoptionAtDistance(adoptionAtDistance);
            }
        }

        public AdoptionAtDistance RetrieveAdoptionAtDistance(int id)
        {
            var retrievedAdoptionAtDistance = _adoptionAtDistanceRepository.RetrieveById(id);
            if (retrievedAdoptionAtDistance == null)
            {
                throw new AdoptionAtDistanceNotFoundException();
            }
            return retrievedAdoptionAtDistance;
        }

        public PaginatedList<AdoptionAtDistance> RetrieveAdoptionsAtDistance(int page = 0, int pageSize = 15, string sortBy = AdoptionAtDistanceSortingFields.UserEmail, bool sortDesc = false)
        {
            return _adoptionAtDistanceRepository.RetrieveAdoptionsAtDistance(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateAdoptionAtDistance(AdoptionAtDistance adoptionAtDistance)
        {
            if (adoptionAtDistance == null)
            {
                throw new AdoptionAtDistanceNotFoundException();
            }
            _adoptionAtDistanceRepository.UpdateAdoptionAtDistance(adoptionAtDistance);
        }
    }
}
