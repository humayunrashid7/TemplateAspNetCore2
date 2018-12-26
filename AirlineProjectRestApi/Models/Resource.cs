using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Models
{
    public abstract class Resource
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
