using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectRestApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                Href = Url.Link(nameof(GetRoot), null),
                Aircrafts = new
                {
                    Href = Url.Link(nameof(AircraftsController.GetAllAircrafts), null)
                },
                AirlineInfo = new
                {
                    Href = Url.Link(nameof(AirlineInfoController.GetAirlineInfo), null)
                }
            };

            return Ok(response);
        }
    }
}
