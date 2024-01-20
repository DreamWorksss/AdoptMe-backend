using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.AdoptionsAtDistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("AdoptionsAtDistance API")]
    [ApiController]
    public class AdoptionAtDistanceController : ControllerBase
    {
        private readonly IAdoptionAtDistanceService _adoptionAtDistanceService;
        private readonly IMapper _mapper;

        public AdoptionAtDistanceController(IServiceProvider service)
        {
            _adoptionAtDistanceService = service.GetRequiredService<IAdoptionAtDistanceService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrieveAdoptionsAtDistance(int page = 0, int pageSize = 15, string sortBy = AdoptionAtDistanceSortingFields.UserEmail, bool sortDesc = false)
        {
            var adoptionsAtDistance = _adoptionAtDistanceService.RetrieveAdoptionsAtDistance(page, pageSize, sortBy, sortDesc);
            return ResponseHandler.HandleResponse(adoptionsAtDistance);
        }

        [HttpGet]
        public IActionResult RetrieveAllAdoptionAtDistance()
        {
            var allAdoptionsAtDistance = _adoptionAtDistanceService.GetAllAdoptionsAtDistance();
            return ResponseHandler.HandleResponse(allAdoptionsAtDistance);
        }

        [HttpGet]
        public IActionResult RetrieveAdoptionAtDistance(int id)
        {
            var adoptionAtDistance = _adoptionAtDistanceService.RetrieveAdoptionAtDistance(id);
            return ResponseHandler.HandleResponse(adoptionAtDistance);
        }

        [HttpPost]
        public IActionResult AddAdoptionAtDistance([FromBody] AdoptionAtDistanceAdditionModel adoptionAtDistanceAdditionModel)
        {
            if (adoptionAtDistanceAdditionModel != null)
            {
                var adoptionAtDistance = _adoptionAtDistanceService.AddAdoptionAtDistance(_mapper.Map<AdoptionAtDistance>(adoptionAtDistanceAdditionModel));
                return ResponseHandler.HandleResponse(adoptionAtDistance);
            }
            return ResponseHandler.HandleResponse(AdoptionAtDistanceErrorMessages.InvalidModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdoptionAtDistance(int id, [FromBody] AdoptionAtDistanceAdditionModel adoptionAtDistanceUpdateModel)
        {
            
            if (adoptionAtDistanceUpdateModel != null)
            {

                var existingAdoptionAtDistance = _adoptionAtDistanceService.RetrieveAdoptionAtDistance(id);
                if (existingAdoptionAtDistance != null)
                {
                    existingAdoptionAtDistance.PetId = adoptionAtDistanceUpdateModel.PetId;
                    existingAdoptionAtDistance.UserName = adoptionAtDistanceUpdateModel.UserName;
                    existingAdoptionAtDistance.PhoneNumber = adoptionAtDistanceUpdateModel.PhoneNumber;
                    existingAdoptionAtDistance.UserEmail = adoptionAtDistanceUpdateModel.UserEmail;
                    existingAdoptionAtDistance.Sum = adoptionAtDistanceUpdateModel.Sum;
                    existingAdoptionAtDistance.Frequency = adoptionAtDistanceUpdateModel.Frequency;
                    existingAdoptionAtDistance.StartDate = adoptionAtDistanceUpdateModel.StartDate;
                    existingAdoptionAtDistance.EndDate = adoptionAtDistanceUpdateModel.EndDate;
                    existingAdoptionAtDistance.PaymentMethod = adoptionAtDistanceUpdateModel.PaymentMethod;

                    _adoptionAtDistanceService.UpdateAdoptionAtDistance(existingAdoptionAtDistance);
                    return ResponseHandler.HandleResponse(existingAdoptionAtDistance);
                }
                else
                {
                    return ResponseHandler.HandleResponse(AdoptionAtDistanceErrorMessages.InexistentModel);
                }
            }

            return ResponseHandler.HandleResponse(AdoptionAtDistanceErrorMessages.InvalidModel);
        }

        [HttpDelete]
        public IActionResult DeleteAdoptionAtDistance(int id)
        {
            _adoptionAtDistanceService.DeleteAdoptionAtDistance(id);
            return ResponseHandler.HandleResponse(id);
        }
    }
}
