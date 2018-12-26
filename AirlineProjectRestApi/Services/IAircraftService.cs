using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Models;

namespace AirlineProjectRestApi.Services
{
    public interface IAircraftService
    {
        IEnumerable<Aircraft> GetAllAircrafts();

        Aircraft GetAircraftById(Guid id);

        Guid CreateAircraft(AircraftFormCreate aircraftFormCreate);

        void DeleteAircraft(Guid aircraftId);

        void UpdateAircraft(Guid aircraftId, AircraftFormUpdate aircraftFormUpdate);
    }
}
