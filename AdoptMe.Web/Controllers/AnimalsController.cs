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
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public AnimalsController(IServiceProvider service)
        {
            _animalService = service.GetRequiredService<IAnimalService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrieveAnimals(int page = 0, int pageSize = 15, string sortBy = AnimalSortingFields.Name, bool sortDesc = false)
        {
            return Ok(_animalService.RetrieveAnimals(page, pageSize, sortBy, sortDesc)); //TODO: add proper response
        }

        [HttpGet]
        public IActionResult RetrieveAnimal(int id)
        {
            return Ok(_animalService.RetrieveAnimal(id)); //TODO: not found exception to be handled by the middleware in the future
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalAdditionModel animalAdditionModel)
        {
            if (animalAdditionModel != null)
            {
                _animalService.AddAnimal(_mapper.Map<Animal>(animalAdditionModel));
                return Ok("Animal added successfully"); //TODO: add proper response, not this bullshit
            }
            return BadRequest("Invalid animal model"); //TODO: add proper response, not this bullshit
        }
    }
}
