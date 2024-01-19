using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.Animals;
using AdoptMe.Web.Models.Donations;
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
        public IActionResult RetrievePetsByShelter([FromQuery] PetFilterFields petFilterFields)
        {
            var pets = _petService.RetrievePetsByShelter(petFilterFields.ShelterId, petFilterFields.Page, petFilterFields.PageSize);
            return ResponseHandler.HandleResponse(pets);
        }
        
        [HttpGet]
        public IActionResult RetrieveAllPets()
        {
            var allPets = _petService.GetAllPets();
            return Ok(allPets);
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

        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, [FromBody] PetAdditionModel petUpdateModel)
        {
            if (petUpdateModel != null)
            {
                var existingPet = _petService.RetrievePet(id);
                if (existingPet != null)
                {
                    _petService.UpdateAnimal(existingPet);
                    return ResponseHandler.HandleResponse(existingPet);
                }
                else
                {
                    return ResponseHandler.HandleResponse(PetErrorMessages.InexistentModel);
                }
            }

            return ResponseHandler.HandleResponse(DonationErrorMessages.InvalidModel);
        }

        [HttpDelete]
        public IActionResult DeletePet(int id)
        {
            _petService.DeleteAnimal(id);
            return ResponseHandler.HandleResponse(id);
        }
    }
}
