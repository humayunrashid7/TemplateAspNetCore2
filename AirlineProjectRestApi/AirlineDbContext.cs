using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineProjectRestApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineProjectRestApi
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions options) : base(options)
        {
        }

        // TODO: Add DbSets 
        public DbSet<AircraftEntity> Aircrafts { get; set; }

    }
}
