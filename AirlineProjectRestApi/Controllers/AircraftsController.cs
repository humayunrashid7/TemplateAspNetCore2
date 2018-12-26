using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Models;
using AirlineProjectRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectRestApi.Controllers
{
    [Route("api/aircrafts")]
    [ApiController]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            this.aircraftService = aircraftService;
        }


        // GET api/aircrafts
        [HttpGet(Name = nameof(GetAllAircrafts))]
        public IActionResult GetAllAircrafts()
        {
            IEnumerable<Aircraft> aircrafts = aircraftService.GetAllAircrafts();

            if (aircrafts == null) return NotFound();

            // Enumerate through each single Aircraft and call CreaLinks method.
            aircrafts = aircrafts.Select(aircraft =>
            {
                aircraft = CreateLinks(aircraft);
                return aircraft;
            });

            var response = new
            {
                Value = aircrafts
            };

            return Ok(response);
        }


        // GET /aircrafts/{aircraftId}
        [HttpGet("{aircraftId}", Name = nameof(GetAircraftById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetAircraftById(Guid aircraftId)
        {
            Aircraft aircraft = aircraftService.GetAircraftById(aircraftId);

            if (aircraft == null) return NotFound();

            return Ok(CreateLinks(aircraft));
        }


        // POST api/aircrafts
        [HttpPost(Name = nameof(CreateAircraft))]
        [ProducesResponseType(400)]
        public IActionResult CreateAircraft([FromBody] AircraftFormCreate newAircraftForm)
        {
            if (newAircraftForm == null) return BadRequest();

            // ASP.NET does validation automatically

            // Do some business rules check here, i.e. Check if Aircraft is over 15 years old
            // If Aircraft doesnt meet requirement, return BadRequest
            /* Example:
             * var maxAge = 15;
             * bool tooOld = aircraft.Age > 15
             * if (tooOld) return BadRequest(new ApiError($"The max age is 15 years"));
             */

            Guid newAircraftId = aircraftService.CreateAircraft(newAircraftForm);

            return CreatedAtRoute(
                routeName: nameof(GetAircraftById), 
                routeValues: new {aircraftId = newAircraftId},
                value: newAircraftForm);
        }

        // DELETE api/aircrafts/{aircraftId}
        [HttpDelete("{aircraftId}", Name = nameof(DeleteAircraftById))]
        [ProducesResponseType(204)]
        public IActionResult DeleteAircraftById(Guid aircraftId)
        {
            aircraftService.DeleteAircraft(aircraftId);
            return NoContent();
        }

        // PUT api/aircrafts/{aircraftId}
        [HttpPut("{aircraftId}")]
        public IActionResult UpdateAircraft(Guid aircraftId, [FromBody] AircraftFormUpdate aircraftForm)
        {
            aircraftService.UpdateAircraft(aircraftId, aircraftForm);

            return NoContent();
        }


        // Method to create Links for the Resource Aircraft
        public Aircraft CreateLinks(Aircraft aircraft)
        {
            var getHref = Url.Link(nameof(GetAircraftById), new {aircraftId = aircraft.Id});
            aircraft.Links.Add(new Link(getHref, "self", Link.GetMethod));

            return aircraft;
        }

    }
}
