using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirlineProjectRestApi.Models
{
    public class Link
    {
        public const string GetMethod = "GET";
        public const string PostMethod = "POST";
        public const string UpdateMethod = "UPDATE";
        public const string DeleteMethod = "DELETE";

        public Link(string href, string relation, string method)
        {
            Href = href;
            Relation = relation;
            Method = method;
        }

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3, PropertyName = "Rel", NullValueHandling = NullValueHandling.Ignore)]
        public string Relation { get; set; }

        [JsonProperty(Order = -2, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }
    }
    
}
