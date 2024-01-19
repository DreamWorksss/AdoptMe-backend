using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.AdoptionRequests;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("AdoptionRequests API")]
    [ApiController]
    public class AdoptionRequestController : ControllerBase
    {
        private readonly IAdoptionRequestService _adoptionRequestService;
        private readonly IMapper _mapper;

        public AdoptionRequestController(IServiceProvider service)
        {
            _adoptionRequestService = service.GetRequiredService<IAdoptionRequestService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrieveAdoptionRequests(int page = 0, int pageSize = 15, string sortBy = AdoptionRequestSortingFields.Name, bool sortDesc = false)
        {
            var adoptionRequests = _adoptionRequestService.RetrieveAdoptionRequests(page, pageSize, sortBy, sortDesc);
            return ResponseHandler.HandleResponse(adoptionRequests);
        }

        [HttpGet]
        public IActionResult RetrieveAllAdoptionRequests()
        {
            var allAdoptionRequests = _adoptionRequestService.GetAllAdoptionRequests();
            return ResponseHandler.HandleResponse(allAdoptionRequests);
        }

        [HttpGet]
        public IActionResult RetrieveAdoptionRequest(int id)
        {
            var adoptionRequest = _adoptionRequestService.RetrieveAdoptionRequest(id);
            return ResponseHandler.HandleResponse(adoptionRequest);
        }

        [HttpPost]
        public IActionResult AddAdoptionRequest([FromBody] AdoptionRequestAdditionModel adoptionRequestAdditionModel)
        {
            if (adoptionRequestAdditionModel != null)
            {
                var adoptionRequest = _adoptionRequestService.AddAdoptionRequest(_mapper.Map<AdoptionRequest>(adoptionRequestAdditionModel));
                return ResponseHandler.HandleResponse(adoptionRequest);
            }
            return ResponseHandler.HandleResponse(AdoptionRequestErrorMessages.InvalidModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdoptionRequest(int id, [FromBody] AdoptionRequestAdditionModel adoptionRequestUpdateModel)
        {
            if (adoptionRequestUpdateModel != null)
            {
                var existingAdoptionRequest = _adoptionRequestService.RetrieveAdoptionRequest(id);
                if (existingAdoptionRequest != null)
                {
                    _adoptionRequestService.UpdateAdoptionRequest(existingAdoptionRequest);
                    return ResponseHandler.HandleResponse(existingAdoptionRequest);
                }
                else
                {
                    return ResponseHandler.HandleResponse(AdoptionRequestErrorMessages.InexistentModel);
                }
            }

            return ResponseHandler.HandleResponse(AdoptionRequestErrorMessages.InvalidModel);
        }

        [HttpDelete]
        public IActionResult DeleteAdoptionRequest(int id)
        {
            _adoptionRequestService.DeleteAdoptionRequest(id);
            return ResponseHandler.HandleResponse(id);
        }
    }
}
