using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.Animals;
using AdoptMe.Web.Models.Pets;
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
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetsController(IServiceProvider service)
        {
            _petService = service.GetRequiredService<IPetService>();
            _mapper = service.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public IActionResult RetrievePets([FromQuery] PetSearchFields petSearchFields)
        {
            var pets = _petService.RetrievePets(petSearchFields.Page, petSearchFields.PageSize, petSearchFields.SortBy, petSearchFields.SortDesc);
            return ResponseHandler.HandleResponse(pets);
        }

        [HttpGet]
        public IActionResult RetrievePet(int id)
        {
            return ResponseHandler.HandleResponse(_petService.RetrievePet(id));
        }

        [HttpPost]
        public IActionResult AddPet([FromBody] PetAdditionModel petAdditionModel)
        {
            if (petAdditionModel != null)
            {
                var pet = _petService.AddPet(_mapper.Map<Pet>(petAdditionModel));
                return ResponseHandler.HandleResponse(pet);
            }
            return ResponseHandler.HandleResponse(PetErrorMessages.InvalidModel);
        }
    }
}
