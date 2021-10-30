using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BedTicket> BedTickets { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CovidTestResult> CovidTestResults { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Data Source=JCC-MAIN;Initial Catalog=Suwahasa;Integrated Security=True");
      }
#endif
#if !DEBUG
	  if (!optionsBuilder.IsConfigured)
	  {
		optionsBuilder.UseSqlServer("Server=tcp:5.189.184.133,1433;Initial Catalog=TestAppDB;Persist Security Info=False;User ID=sa;Password=Codebrix@2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;");
	  }
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BedTicket>(entity =>
            {
                entity.Property(e => e.DateEntered)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BookingFkNavigation)
                    .WithMany(p => p.BedTickets)
                    .HasForeignKey(d => d.BookingFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BedTickets_Booking");

                entity.HasOne(d => d.EnteredByFkNavigation)
                    .WithMany(p => p.BedTickets)
                    .HasForeignKey(d => d.EnteredByFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BedTickets_Employees");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.DateAdmitted).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDischarged).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReservationDate).HasColumnType("datetime");

                entity.Property(e => e.TransportDate).HasColumnType("datetime");

                entity.HasOne(d => d.HospitalFkNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HospitalFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Hospitals");

                entity.HasOne(d => d.PackageFkNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PackageFk)
                    .HasConstraintName("FK_Bookings_Packages");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Users");

                entity.HasOne(d => d.VehicleFkNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.VehicleFk)
                    .HasConstraintName("FK_Bookings_Vehicles");
            });

            modelBuilder.Entity<CovidTestResult>(entity =>
            {
                entity.Property(e => e.DateTested).HasColumnType("datetime");

                entity.HasOne(d => d.BookingFkNavigation)
                    .WithMany(p => p.CovidTestResults)
                    .HasForeignKey(d => d.BookingFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CovidTestResults_Bookings");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.IsAuser)
                    .HasColumnName("IsAUser")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.HospitalFkNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.HospitalFk)
                    .HasConstraintName("FK_Employees_Hospitals");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasOne(d => d.HospitalFkNavigation)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.HospitalFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Packages_Hospitals");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.BookingFkNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Bookings");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.EmployeeFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeFk)
                    .HasConstraintName("FK_Users_Employees");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.DriverFkNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.DriverFk)
                    .HasConstraintName("FK_Vehicles_Employees");

                entity.HasOne(d => d.HospitalFkNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.HospitalFk)
                    .HasConstraintName("FK_Vehicles_Hospitals");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
