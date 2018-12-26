using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AirlineProjectRestApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment environment;

        public JsonExceptionFilter(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (environment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error occured.";
                error.Detail = context.Exception.Message;
            }



            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
