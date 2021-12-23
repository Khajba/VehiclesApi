using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext(DbContextOptions<VehiclesContext> options)
    : base(options)
        {
        }

        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<VehiclesPersons> VehiclesPersons { get; set; }
        public DbSet<Persons> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Method 1 - Call configure method
            var vehiclesConfigurations = new VehiclesConfiguration();
            vehiclesConfigurations.Configure(modelBuilder.Entity<Vehicles>());

            var vehiclesPersonsConfigurations = new VehiclesPersonsConfiguration();
            vehiclesPersonsConfigurations.Configure(modelBuilder.Entity<VehiclesPersons>());

            var personsConfigurations = new PersonsConfiguration();
            personsConfigurations.Configure(modelBuilder.Entity<Persons>());
        }
     }
   }


