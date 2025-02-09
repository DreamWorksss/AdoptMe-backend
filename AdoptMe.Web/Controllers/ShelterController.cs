﻿using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Service.Exceptions;
using AdoptMe.Web.Models.Shelters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using AdoptMe.Service.Exceptions.Shelters;
using AdoptMe.Web.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult RetrieveShelters(int page = 0, int pageSize = 15, string sortBy = PetSortingFields.Name, bool sortDesc = false)
        {
            var shelters = _shelterService.RetrieveShelters(page, pageSize, sortBy, sortDesc);
            return Ok(shelters);
        }

        [HttpGet]
        public IActionResult RetrieveAllShelters()
        {
            var allShelters = _shelterService.GetAllShelters();
            return Ok(allShelters);
        }

        [HttpGet]
        public IActionResult RetrieveShelter(int id)
        {
            var shelter = _shelterService.RetrieveShelter(id);
            return Ok(shelter);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddShelter([FromBody] ShelterAdditionModel shelterAdditionModel)
        {
            if (shelterAdditionModel != null)
            {
                var shelter = _shelterService.AddShelter(_mapper.Map<Shelter>(shelterAdditionModel));
                return ResponseHandler.HandleResponse(shelter);
            }
            return ResponseHandler.HandleResponse(ShelterErrorMessages.InvalidModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateShelter(int id, [FromBody] ShelterUpdateModel shelterUpdateModel)
        {
            if (shelterUpdateModel != null)
            {
                var existingShelter = _shelterService.RetrieveShelter(id);
                if (existingShelter != null)
                {
                    existingShelter.Name = shelterUpdateModel.Name;
                    existingShelter.ImageUrl = shelterUpdateModel.ImageUrl;

                    _shelterService.UpdateShelter(existingShelter);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }

            return ResponseHandler.HandleResponse(ShelterErrorMessages.InvalidModel);
        }


        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult DeleteShelter(int id)
        {
            _shelterService.DeleteShelter(id);
            return Ok();
        }

        [HttpPost]
        [Route("/[action]")]
        public IActionResult InsertShelters([FromBody] List<ShelterAdditionModel> shelters)
        {
            _shelterService.AddShelters(_mapper.Map<List<Shelter>>(shelters));
            return Ok();
        }
    }
}
