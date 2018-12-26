using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineProjectRestApi.Filters;
using AirlineProjectRestApi.Infrastructure;
using AirlineProjectRestApi.Models;
using AirlineProjectRestApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace AirlineProjectRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // This is the basic info about the airline stored in "appsetting.json".
            services.Configure<AirlineInfo>(Configuration.GetSection("Info"));

            //            // Use Sql Server Database
            //            const string connectionString = "Server=HR-PC;Database=AirlineDbTest;Trusted_Connection=True;";
            //            services.AddDbContext<AirlineDbContext>(
            //                options => options.UseSqlServer(connectionString));

            // Use an in memory Database for development
            services.AddDbContext<AirlineDbContext>(
                options => options.UseInMemoryDatabase("airlinedb")
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Implement the AircraftService, AddScoped is used because we cant one instance for each separate request
            services.AddScoped<IAircraftService, DefaultAircraftService>();

            // Add Filter for Json Exception Handlings
            services.AddMvc(options =>
            {
                options.Filters.Add<JsonExceptionFilter>();
            });

            // Config JSON Result to display as PascalCase (First Letter is Capitalized)
            services.AddMvc().AddJsonOptions(options =>
            {
                if (options.SerializerSettings.ContractResolver != null)
                {
                    var castedResolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                    castedResolver.NamingStrategy = null;
                }
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            // Api Versioning: Add Nuget Package 'Microsoft.AspNetCore.Mvc.Versioning'
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            // Add CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp",
                    policy => policy.AllowAnyOrigin());
            });

            // Add Automapper Service (NuGet pkg: Automapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(
                options => options.AddProfile<MappingProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseCors("AllowMyApp");
            app.UseMvc();
        }
    }
}
