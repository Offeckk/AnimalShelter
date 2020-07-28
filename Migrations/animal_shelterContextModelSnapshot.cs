﻿// <auto-generated />
using System;
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter.Migrations
{
    [DbContext(typeof(animal_shelterContext))]
    partial class animal_shelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalShelter.Models.Cat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnName("breed")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("CentreId")
                        .HasColumnName("centre_id")
                        .HasColumnType("int(11)");

                    b.Property<byte>("Cleansed")
                        .HasColumnName("cleansed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IntelligenceCoefficient")
                        .HasColumnName("intelligence_coefficient")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CentreId")
                        .HasName("fk_cats_centres");

                    b.ToTable("cats");
                });

            modelBuilder.Entity("AnimalShelter.Models.Centre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("name");

                    b.ToTable("centres");
                });

            modelBuilder.Entity("AnimalShelter.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnName("breed")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("CentreId")
                        .HasColumnName("centre_id")
                        .HasColumnType("int(11)");

                    b.Property<byte>("Cleansed")
                        .HasColumnName("cleansed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CentreId")
                        .HasName("fk_dogs_centres");

                    b.ToTable("dogs");
                });

            modelBuilder.Entity("AnimalShelter.Models.Cat", b =>
                {
                    b.HasOne("AnimalShelter.Models.Centre", "Centre")
                        .WithMany("Cats")
                        .HasForeignKey("CentreId")
                        .HasConstraintName("fk_cats_centres");
                });

            modelBuilder.Entity("AnimalShelter.Models.Dog", b =>
                {
                    b.HasOne("AnimalShelter.Models.Centre", "Centre")
                        .WithMany("Dogs")
                        .HasForeignKey("CentreId")
                        .HasConstraintName("fk_dogs_centres");
                });
#pragma warning restore 612, 618
        }
    }
}
