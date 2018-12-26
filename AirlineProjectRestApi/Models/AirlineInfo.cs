using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Models
{
    public class AirlineInfo : Resource
    {
        public string Title { get; set; }
        public string TagLine { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public AddressAirlineInfo Location { get; set; }
    }

    public class AddressAirlineInfo
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
