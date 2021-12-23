using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context
{
    public class VehiclesPersonsConfiguration : IEntityTypeConfiguration<VehiclesPersons> 
    {
        public void Configure(EntityTypeBuilder<VehiclesPersons> builder)
        {
            // Specify Table name and Schema
            builder.ToTable("VehiclesPersons", "dbo");

            // Specify primary key 
            // Primary key constraint name is also specified
            builder.HasKey(x => x.Id)
                .HasName("PK_VehiclesPersons");

            // Required and MaxLength
            builder.HasOne(x => x.Vehicles)
                .WithMany(e=>e.VehiclesPersons)
                .HasForeignKey(t => t.VehicleId);

            // Required and MaxLength
            builder.HasOne(x => x.Persons)
                .WithMany(e => e.VehiclesPersons)
                .HasForeignKey(t => t.PersonId);


            builder.Property(x => x.OwnerType)
                .HasMaxLength(50)
                .HasColumnName("OwnerType")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

            builder.Property(x => x.CreateDateTime)
                .HasColumnName("CreateDateTime");
        }
    }
}
