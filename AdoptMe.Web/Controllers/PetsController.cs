using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.Models.Animals;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [SwaggerTag("Animals API")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _animalService;
        private readonly IMapper _mapper;

        public PetsController(IServiceProvider service)
        {
            _animalService = service.GetRequiredService<IPetService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrievePets(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            return Ok(_animalService.RetrieveAnimals(page, pageSize, sortBy, sortDesc)); //TODO: add proper response
        }

        [HttpGet]
        public IActionResult RetrievePet(int id)
        {
            return Ok(_animalService.RetrieveAnimal(id)); //TODO: not found exception to be handled by the middleware in the future
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] PetAdditionModel animalAdditionModel)
        {
            if (animalAdditionModel != null)
            {
                _animalService.AddPet(_mapper.Map<Pet>(animalAdditionModel));
                return Ok("Animal added successfully"); //TODO: add proper response, not this bullshit
            }
            return BadRequest("Invalid animal model"); //TODO: add proper response, not this bullshit
        }
    }
}
