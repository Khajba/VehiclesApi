using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context
{
    public class VehiclesConfiguration : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> builder)
        {
            // Specify Table name and Schema
            builder.ToTable("Vehicles", "dbo");

            // Specify primary key 
            // Primary key constraint name is also specified
            builder.HasKey(x => x.Id)
                .HasName("PK_Vehicle");

            // Required and MaxLength
            builder.Property(x => x.MarkEng)
                .HasMaxLength(50)
                .HasColumnName("MarkEng")
                .IsRequired();

            builder.Property(x => x.MarkGeo)
                .HasMaxLength(50)
                .HasColumnName("MarkGeo")
                .IsRequired();

            builder.Property(x => x.ModelEng)
                .HasMaxLength(50)
                .HasColumnName("ModelEng")
                .IsRequired();

            builder.Property(x => x.ModelGeo)
                .HasMaxLength(50)
                .HasColumnName("ModelGeo")
                .IsRequired();

            builder.Property(x => x.VinCode)
                .HasMaxLength(50)
                .HasColumnName("VinCode")
                .IsRequired();

            builder.Property(x => x.VehicleNumber)
                .HasMaxLength(50)
                .HasColumnName("VehicleNumber")
                .IsRequired();

            builder.Property(x => x.Color)
                .HasMaxLength(50)
                .HasColumnName("Color")
                .IsRequired();
        }
    }
}
