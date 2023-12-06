using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("Shelters API")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly IMapper _mapper;

        public ShelterController(IServiceProvider service)
        {
            _shelterService = service.GetRequiredService<IShelterService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = AnimalSortingFields.Name, bool sortDesc = false)
        {
            return Ok(_shelterService.RetrieveShelters(page, pageSize, sortBy, sortDesc)); //TODO: add proper response
        }

        [HttpGet]
        public IActionResult RetrieveShelter(int id)
        {
            return Ok(_shelterService.RetrieveShelter(id)); //TODO: not found exception to be handled by the middleware in the future
        }

        [HttpPost]
        public IActionResult AddShelter([FromBody] ShelterAdditionModel shelterAdditionModel)
        {
            if (shelterAdditionModel != null)
            {
                _shelterService.AddShelter(_mapper.Map<Shelter>(shelterAdditionModel));
                return Ok("Shelter added successfully"); //TODO: add proper response
            }
            return BadRequest("Invalid shelter model"); //TODO: add proper response
        }
    }
}
