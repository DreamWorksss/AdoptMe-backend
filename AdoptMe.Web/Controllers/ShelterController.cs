using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Service.Exceptions;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

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
            try
            {
                var shelters = _shelterService.RetrieveShelters(page, pageSize, sortBy, sortDesc);
                return Ok(shelters);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ShelterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public IActionResult RetrieveShelter(int id)
        {
            try
            {
                var shelter = _shelterService.RetrieveShelter(id);
                return Ok(shelter);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ShelterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddShelter([FromBody] ShelterAdditionModel shelterAdditionModel)
        {
            try
            {
                if (shelterAdditionModel != null)
                {
                    _shelterService.AddShelter(_mapper.Map<Shelter>(shelterAdditionModel));
                    return Ok("Shelter added successfully");
                }
                return BadRequest("Invalid shelter model");
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
