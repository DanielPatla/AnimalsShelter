﻿// <auto-generated />
using AnimalsShelter.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalsShelter.DataAccess.Migrations
{
    [DbContext(typeof(AnimalsShelterStorageContext))]
    [Migration("20210324153330_LastMigrationFailed")]
    partial class LastMigrationFailed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("SpecieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Specie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Animal", b =>
                {
                    b.HasOne("AnimalsShelter.DataAccess.Entities.Breed", null)
                        .WithMany("Animals")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Breed", b =>
                {
                    b.HasOne("AnimalsShelter.DataAccess.Entities.Specie", null)
                        .WithMany("Breeds")
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Breed", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("AnimalsShelter.DataAccess.Entities.Specie", b =>
                {
                    b.Navigation("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
