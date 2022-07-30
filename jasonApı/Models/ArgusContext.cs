using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jasonApı.Models
{
    public partial class ArgusContext : DbContext
    {

       


            public ArgusContext()
        {
        }

        public ArgusContext(DbContextOptions<ArgusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArgusDatum> ArgusData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArgusDatum>(entity =>
            {
                entity.ToTable("argusData");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .HasColumnName("age")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
