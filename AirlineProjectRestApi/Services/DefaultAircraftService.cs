using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Entities;
using AirlineProjectRestApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirlineProjectRestApi.Services
{
    public class DefaultAircraftService : IAircraftService
    {
        private readonly AirlineDbContext context;
        private readonly IMapper mapper;

        public DefaultAircraftService(AirlineDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            IEnumerable<AircraftEntity> aircrafts = context.Aircrafts.ToList();
            if (aircrafts.Count() == 0) return null;

            return mapper.Map<IEnumerable<Aircraft>>(aircrafts);
        }


        public Aircraft GetAircraftById(Guid id)
        {
            AircraftEntity entity = context.Aircrafts.SingleOrDefault(a => a.Id == id);

            if (entity == null) return null;

            // Return Mapp.Map to Aircraft(JsonResource) from the Aircraft(DatabaseEntity)
            return mapper.Map<Aircraft>(entity);
        }


        public Guid CreateAircraft(AircraftFormCreate aircraftForm)
        {
            Guid newId = Guid.NewGuid();
            AircraftEntity newAircraftEntity = mapper.Map<AircraftEntity>(aircraftForm);

            context.Aircrafts.Add(newAircraftEntity);

            var created = context.SaveChanges();
            if (created < 1) throw new InvalidOperationException("Could not create new aircraft.");

            return newId;
        }

        public void DeleteAircraft(Guid aircraftId)
        {
            AircraftEntity aircraft = context.Aircrafts.SingleOrDefault(a => a.Id == aircraftId);
            if (aircraft == null) return;

            context.Remove(aircraft);
            context.SaveChanges();
        }

        public void UpdateAircraft(Guid aircraftId, AircraftFormUpdate aircraftFormUpdate)
        {
            AircraftEntity aircrafEntity = context.Aircrafts.SingleOrDefault(a => a.Id == aircraftId);
            
            // Mapper.Map(Source, Dest), It converts the data from AircraftFormUpdate into AircraftEntity
            // by Overriding the fields. After all it is required is to save changes
            mapper.Map(aircraftFormUpdate, aircrafEntity);

            context.SaveChanges();
        }
    }
}
