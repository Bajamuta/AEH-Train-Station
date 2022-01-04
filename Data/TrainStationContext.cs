using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrainStation.Models;

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
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Conductor> Conductors { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TypeOfTicket> TypesOfTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TrainStation;User=sa; Password='P@$$w0rd!';");
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

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.ToTable("Cars");

                entity.HasIndex(e => e.CarID, "IX_Cars_CarID");

                entity.HasIndex(e => e.RideID, "IX_Cars_RideID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.CarID).HasColumnName("CarID");

                entity.Property(e => e.RideID).HasColumnName("RideID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.RideID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasIndex(e => e.ConductorID, "IX_Conductors_ConductorID");

                entity.HasIndex(e => e.RideID, "IX_Conductors_RideID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.ConductorID).HasColumnName("ConductorID");

                entity.Property(e => e.RideID).HasColumnName("RideID");

                entity.HasOne(d => d.ConductorEmployee)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.ConductorID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.RideID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.PermissionID, "IX_Employee_PermissionID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.PermissionID).HasColumnName("PermissionID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PermissionID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("Engine");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Journey>(entity =>
            {
                entity.ToTable("Journey");

                entity.HasIndex(e => e.DayId, "IX_Journey_DayID");

                entity.HasIndex(e => e.DestinationPlaceId, "IX_Journey_DestinationPlaceID");

                entity.HasIndex(e => e.RideId, "IX_Journey_RideID");

                entity.HasIndex(e => e.StartingPlaceId, "IX_Journey_StartingPlaceID");

                entity.HasIndex(e => e.StatusId, "IX_Journey_StatusID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.DayId).HasColumnName("DayID");

                entity.Property(e => e.DestinationPlaceId).HasColumnName("DestinationPlaceID");

                entity.Property(e => e.RideId).HasColumnName("RideID");

                entity.Property(e => e.StartingPlaceId).HasColumnName("StartingPlaceID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TicketBasePrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DestinationPlace)
                    .WithMany(p => p.JourneyDestinationPlaces)
                    .HasForeignKey(d => d.DestinationPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.RideId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StartingPlace)
                    .WithMany(p => p.JourneyStartingPlaces)
                    .HasForeignKey(d => d.StartingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.ToTable("Ride");

                entity.HasIndex(e => e.DriverId, "IX_Ride_DriverID");

                entity.HasIndex(e => e.EngineId, "IX_Ride_EngineID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.EngineId).HasColumnName("EngineID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.HasIndex(e => e.CarID, "IX_Ticket_CarID");

                entity.HasIndex(e => e.TypeOfTicketID, "IX_Ticket_TypeID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.CarID).HasColumnName("CarID");

                entity.Property(e => e.SoldPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TypeOfTicketID).HasColumnName("TypeID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TypeOfTicket)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TypeOfTicketID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.ToTable("Tickets");

                entity.HasIndex(e => e.JourneyID, "IX_Tickets_JourneyID");

                entity.HasIndex(e => e.TicketID, "IX_Tickets_TicketID");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.JourneyID).HasColumnName("JourneyID");

                entity.Property(e => e.TicketID).HasColumnName("TicketID");

                entity.HasOne(d => d.Journey)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.JourneyID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TicketID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TypeOfTicket>(entity =>
            {
                entity.ToTable("TypeOfTicket");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
