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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Method 1 - Call configure method
            var vehiclesConfigurations = new VehiclesEntityTypeConfiguration();
            vehiclesConfigurations.Configure(modelBuilder.Entity<Vehicles>());

            // Method 2 - ApplyConfiguration method
            // modelBuilder.ApplyConfiguration(studentConfigurations);

            //Method 3 - Apply all from an assembly
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehiclesContext).Assembly);
        }
     }
   }

