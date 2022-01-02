using System;
using Microsoft.EntityFrameworkCore;
using TrainStation.Models;
using Type = TrainStation.Models.Type;

#nullable disable

namespace TrainStation.Data
{
    public partial class TrainStationContext : DbContext
    {
        public TrainStationContext()
        {
        }

        public TrainStationContext(DbContextOptions<TrainStationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Ride> Ride { get; set; }
        public virtual DbSet<Conductors> Conductors { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Journey> Journey { get; set; }
        public virtual DbSet<Day> Day { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:TrainDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Ticket>()
                .ToTable("Ticket")
                .Property(t => t.ID).HasColumnName("ID");

            modelBuilder.Entity<Type>()
                .ToTable("Type")
                .Property(t => t.ID).HasColumnName("ID");

            modelBuilder.Entity<Permission>()
                .ToTable("Permission")
                .Property(p => p.ID).HasColumnName("ID");

            modelBuilder.Entity<Status>()
                .ToTable("Status")
                .Property(s => s.ID).HasColumnName("ID");

            modelBuilder.Entity<Car>()
                .ToTable("Car")
                .Property(c => c.ID).HasColumnName("ID");

            modelBuilder.Entity<Day>()
                .ToTable("Day")
                .Property(d => d.ID).HasColumnName("ID");

            modelBuilder.Entity<Place>()
                .ToTable("Place")
                .Property(p => p.ID).HasColumnName("ID");

            modelBuilder.Entity<Conductors>()
                .ToTable("Conductors")
                .Property(c => c.ID).HasColumnName("ID");

            modelBuilder.Entity<Engine>()
                .ToTable("Engine")
                .Property(e => e.ID).HasColumnName("ID");

            modelBuilder.Entity<Ride>()
                .ToTable("Ride")
                .Property(r => r.ID).HasColumnName("ID");

            modelBuilder.Entity<Cars>()
                .ToTable("Cars")
                .Property(c => c.ID).HasColumnName("ID");

            modelBuilder.Entity<Tickets>()
                .ToTable("Tickets")
                .Property(t => t.ID).HasColumnName("ID");

            modelBuilder.Entity<Journey>()
                .ToTable("Journey")
                .Property(j => j.ID).HasColumnName("ID");
            
            modelBuilder.Entity<Employee>()
                .HasOne<Permission>(e => e.Type)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PermissionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne<Type>(t => t.Type)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TypeID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne<Car>(t => t.Car)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CarID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne<Engine>(r => r.Engine)
                .WithMany(e => e.Rides)
                .HasForeignKey(r => r.EngineID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne<Employee>(r => r.Driver)
                .WithMany(e => e.Rides)
                .HasForeignKey(r => r.DriverID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conductors>()
                .HasOne<Ride>(c => c.Ride)
                .WithMany(r => r.ConductorsList)
                .HasForeignKey(c => c.RideID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conductors>()
                .HasOne<Employee>(c => c.Conductor)
                .WithMany(e => e.ConductorsList)
                .HasForeignKey(c => c.ConductorID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cars>()
                .HasOne<Ride>(c => c.Ride)
                .WithMany(r => r.CarsList)
                .HasForeignKey(c => c.RideID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cars>()
                .HasOne<Car>(c => c.Car)
                .WithMany(c => c.CarsList)
                .HasForeignKey(c => c.CarID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journey>()
                .HasOne<Day>(j => j.Day)
                .WithMany(d => d.Journeys)
                .HasForeignKey(j => j.DayID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journey>()
                .HasOne<Status>(j => j.Status)
                .WithMany(s => s.Journeys)
                .HasForeignKey(j => j.StatusID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journey>()
                .HasOne<Ride>(j => j.Ride)
                .WithMany(r => r.Journeys)
                .HasForeignKey(j => j.RideID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journey>()
                .HasOne<Place>(j => j.StartingPlace)
                .WithMany(p => p.JourneysStarting)
                .HasForeignKey(j => j.StartingPlaceID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journey>()
                .HasOne<Place>(j => j.DestinationPlace)
                .WithMany(p => p.JourneysDestinations)
                .HasForeignKey(j => j.DestinationPlaceID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tickets>()
                .HasOne<Ticket>(t => t.Ticket)
                .WithMany(t => t.TicketsList)
                .HasForeignKey(t => t.TicketID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tickets>()
                .HasOne<Journey>(t => t.Journey)
                .WithMany(j => j.TicketsList)
                .HasForeignKey(t => t.JourneyID)
                .OnDelete(DeleteBehavior.NoAction);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
