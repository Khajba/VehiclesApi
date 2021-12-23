using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context
{
    public class PersonsConfiguration : IEntityTypeConfiguration<Persons> 
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            // Specify Table name and Schema
            builder.ToTable("Persons", "dbo");

            // Specify primary key 
            // Primary key constraint name is also specified
            builder.HasKey(x => x.Id)
                .HasName("PK_Persons");            

            builder.Property(x => x.PersonNumber)
                .HasMaxLength(50)
                .HasColumnName("PersonNumber")
                .IsRequired();

            builder.Property(x => x.Firstname)
                .HasColumnName("Firstname")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Lastname)
                .HasColumnName("Lastname")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
