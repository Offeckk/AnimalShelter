using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnimalShelter.Models
{
    public partial class animal_shelterContext : DbContext
    {
        public animal_shelterContext()
        {
        }

        public animal_shelterContext(DbContextOptions<animal_shelterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Centre> Centres { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=NeshtoNovo0026;database=animal_shelter");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("cats");

                entity.HasIndex(e => e.CentreId)
                    .HasName("fk_cats_centres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasColumnName("breed")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentreId)
                    .HasColumnName("centre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cleansed)
                    .HasColumnName("cleansed")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IntelligenceCoefficient)
                    .HasColumnName("intelligence_coefficient")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Centre)
                    .WithMany(p => p.Cats)
                    .HasForeignKey(d => d.CentreId)
                    .HasConstraintName("fk_cats_centres");
            });

            modelBuilder.Entity<Centre>(entity =>
            {
                entity.ToTable("centres");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("dogs");

                entity.HasIndex(e => e.CentreId)
                    .HasName("fk_dogs_centres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasColumnName("breed")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentreId)
                    .HasColumnName("centre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cleansed)
                    .HasColumnName("cleansed")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Centre)
                    .WithMany(p => p.Dogs)
                    .HasForeignKey(d => d.CentreId)
                    .HasConstraintName("fk_dogs_centres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
