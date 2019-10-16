using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace MilesPerGallon
{
    public partial class MPGDatabaseContext : DbContext
    {
        public MPGDatabaseContext()
        {
        }

        public MPGDatabaseContext(DbContextOptions<MPGDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DriverInfo> DriverInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DriverInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FillupDate).HasColumnType("date");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
