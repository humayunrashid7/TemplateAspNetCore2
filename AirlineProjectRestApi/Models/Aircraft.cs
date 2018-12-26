using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Models
{
    // Resource class that will be return via Json to client
    public class Aircraft : Resource
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Fin { get; set; }
        public string ManufactureDate { get; set; }
        public int Capacity { get; set; }
    }
}
