using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProjectRestApi.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }

        public ApiError()
        {
        }

        public ApiError(string message)
        {
            this.Message = message;
        }
    }
}
