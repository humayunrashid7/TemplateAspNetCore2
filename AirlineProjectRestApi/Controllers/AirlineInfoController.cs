using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirlineProjectRestApi.Controllers
{
    [Route("api/airlineinfo")]
    [ApiController]
    public class AirlineInfoController : ControllerBase
    {
        private readonly AirlineInfo airlineInfo;

        public AirlineInfoController(IOptions<AirlineInfo> airlineInfoWrapper)
        {
            this.airlineInfo = airlineInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetAirlineInfo))]
        public ActionResult<AirlineInfo> GetAirlineInfo() //Used ActionResult instead of IActionResult because to return strongly typed resource.
        {
            var href = Url.Link(nameof(GetAirlineInfo), null);

            airlineInfo.Links.Add(new Link(href, "self", Link.GetMethod));
            return airlineInfo;
        }
    }
}
