using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Entities;
using AirlineProjectRestApi.Models;
using AutoMapper;

namespace AirlineProjectRestApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create Map from AircraftEntity to Aircraft Resource
            CreateMap<AircraftEntity, Aircraft>();

            // Create Map from AircraftFormCreate to Aircraft Entity
            CreateMap<AircraftFormCreate, AircraftEntity>();

            // Create Map from AircraftFormUpdate to Aircraft Entity
            CreateMap<AircraftFormUpdate, AircraftEntity>();
        }
    }
}
