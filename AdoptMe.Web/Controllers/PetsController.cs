using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.Animals;
using AdoptMe.Web.Models.Donations;
using AdoptMe.Web.Models.Pets;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult RetrievePetWithRequests(int id)
        {
            return ResponseHandler.HandleResponse(_petService.RetrievePetWithRequests(id));
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public IActionResult UpdatePet(int id, [FromBody] PetUpdateModel petUpdateModel)
        {
            if (petUpdateModel != null)
            {
                var existingPet = _petService.RetrievePet(id);
                if (existingPet != null)
                {
                    existingPet.Name = petUpdateModel.Name;
                    existingPet.Description = petUpdateModel.Description;
                    existingPet.Gender = petUpdateModel.Gender;
                    existingPet.Birthdate = petUpdateModel.Birthdate;
                    existingPet.Color = petUpdateModel.Color;
                    existingPet.ImageUrl = petUpdateModel.ImageUrl;
                    existingPet.ShelterId = petUpdateModel.ShelterId;


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
        [Authorize]
        public IActionResult DeletePet(int id)
        {
            _petService.DeleteAnimal(id);
            return ResponseHandler.HandleResponse(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult AcceptPetAdoption(int id)
        {
            _petService.AcceptPetAdoption(id);
            return ResponseHandler.HandleResponse(id);
        }

        [HttpPost]
        [Route("/[action]")]
        public IActionResult InsertPets([FromBody] List<PetAdditionModel> pets)
        {
            _petService.AddPets(_mapper.Map<List<Pet>>(pets));
            return Ok();
        }
    }
}
