using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Entities
{
    // Entity class that is mapped to the Database table
    public class AircraftEntity
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
