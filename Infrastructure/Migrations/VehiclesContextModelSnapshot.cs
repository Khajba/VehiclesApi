﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(VehiclesContext))]
    partial class VehiclesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Entities.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Lastname");

                    b.Property<string>("PersonNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PersonNumber");

                    b.HasKey("Id")
                        .HasName("PK_Persons");

                    b.ToTable("Persons", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.Vehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Color");

                    b.Property<string>("MarkEng")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MarkEng");

                    b.Property<string>("MarkGeo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MarkGeo");

                    b.Property<string>("ModelEng")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ModelEng");

                    b.Property<string>("ModelGeo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ModelGeo");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VehicleNumber");

                    b.Property<string>("VinCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VinCode");

                    b.HasKey("Id")
                        .HasName("PK_Vehicle");

                    b.ToTable("Vehicles", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.VehiclesPersons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDateTime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("OwnerType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("OwnerType");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_VehiclesPersons");

                    b.HasIndex("PersonId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclesPersons", "dbo");
                });

            modelBuilder.Entity("Infrastructure.Entities.VehiclesPersons", b =>
                {
                    b.HasOne("Infrastructure.Entities.Persons", "Persons")
                        .WithMany("VehiclesPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Vehicles", "Vehicles")
                        .WithMany("VehiclesPersons")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persons");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Infrastructure.Entities.Persons", b =>
                {
                    b.Navigation("VehiclesPersons");
                });

            modelBuilder.Entity("Infrastructure.Entities.Vehicles", b =>
                {
                    b.Navigation("VehiclesPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
