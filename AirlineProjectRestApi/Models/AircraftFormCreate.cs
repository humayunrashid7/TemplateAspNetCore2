using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Models
{
    // Info comes from an Add Aircraft Form
    public class AircraftFormCreate
    {
        [Required]
        [Display(Name = "Manufacturer", Description = "Aircraft manufacturer company name")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Model", Description = "Aircraft model name")]
        public string Model { get; set; }

        public string Registration { get; set; }
        public string Fin { get; set; }
        public string ManufactureDate { get; set; }
        public int Capacity { get; set; }
    }
}
