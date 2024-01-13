using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.Donations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("Donations API")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;
        private readonly IMapper _mapper;

        public DonationController(IServiceProvider service)
        {
            _donationService = service.GetRequiredService<IDonationService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrieveDonations(int page = 0, int pageSize = 15, string sortBy = DonationSortingFields.UserEmail, bool sortDesc = false)
        {
            var donations = _donationService.RetrieveDonations(page, pageSize, sortBy, sortDesc);
            return ResponseHandler.HandleResponse(donations);
        }

        [HttpGet]
        public IActionResult RetrieveAllDonations()
        {
            var allDonations = _donationService.GetAllDonations();
            return ResponseHandler.HandleResponse(allDonations);
        }

        [HttpGet]
        public IActionResult RetrieveDonation(int id)
        {
            var donation = _donationService.RetrieveDonation(id);
            return ResponseHandler.HandleResponse(donation);
        }

        [HttpPost]
        public IActionResult AddDonation([FromBody] DonationAdditionModel donationAdditionModel)
        {
            if (donationAdditionModel != null)
            {
                var donation = _donationService.AddDonation(_mapper.Map<Donation>(donationAdditionModel));
                return ResponseHandler.HandleResponse(donation);
            }
            return ResponseHandler.HandleResponse(DonationErrorMessages.InvalidModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDonation(int id, [FromBody] DonationAdditionModel donationUpdateModel)
        {
            if (donationUpdateModel != null)
            {
                var existingDonation = _donationService.RetrieveDonation(id);
                if (existingDonation != null)
                {
                    _donationService.UpdateDonation(existingDonation);
                    return ResponseHandler.HandleResponse(existingDonation);
                }
                else
                {
                    return ResponseHandler.HandleResponse(DonationErrorMessages.InexistentModel);
                }
            }

            return ResponseHandler.HandleResponse(DonationErrorMessages.InvalidModel);
        }

        [HttpDelete]
        public IActionResult DeleteDonation(int id)
        {
            _donationService.DeleteDonation(id);
            return ResponseHandler.HandleResponse(id);
        }
    }
}
