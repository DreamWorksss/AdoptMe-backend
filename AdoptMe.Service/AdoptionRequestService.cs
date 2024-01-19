using AdoptMe.Common.CommonConstants;
using AdoptMe.Common.Models;
using AdoptMe.Repository.Interfaces;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Exceptions.AdoptionRequests;
using AdoptMe.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AdoptMe.Service
{
    public class AdoptionRequestService : IAdoptionRequestService
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;

        public AdoptionRequestService(IServiceProvider serviceProvider)
        {
            _adoptionRequestRepository = serviceProvider.GetRequiredService<IAdoptionRequestRepository>();
        }

        public List<AdoptionRequest> GetAllAdoptionRequests()
        {
            return _adoptionRequestRepository.GetAllAdoptionRequests();
        }

        public AdoptionRequest AddAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            return _adoptionRequestRepository.Add(adoptionRequest);
        }

        public void DeleteAdoptionRequest(int adoptionRequestId)
        {
            var adoptionRequest = _adoptionRequestRepository.RetrieveById(adoptionRequestId);
            if (adoptionRequest != null)
            {
                _adoptionRequestRepository.DeleteAdoptionRequest(adoptionRequest);
            }
        }

        public AdoptionRequest RetrieveAdoptionRequest(int id)
        {
            var retrievedAdoptionRequest = _adoptionRequestRepository.RetrieveById(id);
            if (retrievedAdoptionRequest == null)
            {
                throw new AdoptionRequestNotFoundException();
            }
            return retrievedAdoptionRequest;
        }

        public PaginatedList<AdoptionRequest> RetrieveAdoptionRequests(int page = 0, int pageSize = 15, string sortBy = AdoptionRequestSortingFields.Name, bool sortDesc = false)
        {
            return _adoptionRequestRepository.RetrieveAdoptionRequests(page, pageSize, sortBy, sortDesc);
        }

        public void UpdateAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            if (adoptionRequest == null)
            {
                throw new AdoptionRequestNotFoundException();
            }
            _adoptionRequestRepository.UpdateAdoptionRequest(adoptionRequest);
        }
    }
}
