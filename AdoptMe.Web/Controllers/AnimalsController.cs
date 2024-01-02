using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.Models.Pets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("Pets API")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetsController(IServiceProvider service)
        {
            _petService = service.GetRequiredService<IPetService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            return Ok(_petService.RetrievePets(page, pageSize, sortBy, sortDesc)); //TODO: add proper response
        }

        [HttpGet]
        public IActionResult RetrievePet(int id)
        {
            return Ok(_petService.RetrievePet(id)); //TODO: not found exception to be handled by the middleware in the future
        }

        [HttpPost]
        public IActionResult AddPet([FromBody] PetAdditionModel petAdditionModel)
        {
            if (petAdditionModel != null)
            {
                _petService.AddPet(_mapper.Map<Pet>(petAdditionModel));
                return Ok("Pet added successfully"); //TODO: add proper response, not this bullshit
            }
            return BadRequest("Invalid pet model"); //TODO: add proper response, not this bullshit
        }
    }
}
