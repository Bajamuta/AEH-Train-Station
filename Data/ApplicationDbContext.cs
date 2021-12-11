using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainStation.Models;
using Type = TrainStation.Models.Type;

namespace TrainStation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TrainStation");
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TrainStation;User=sa; Password='P@$$w0rd!';");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Permission>(e => e.Type)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PermissionID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
                .HasOne<Type>(t => t.Type)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
                .HasOne<Car>(t => t.Car)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CarID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ride>()
                .HasOne<Engine>(r => r.Engine)
                .WithMany(e => e.Rides)
                .HasForeignKey(r => r.EngineID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ride>()
                .HasOne<Employee>(r => r.Driver)
                .WithMany(e => e.Rides)
                .HasForeignKey(r => r.DriverID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Conductors>()
                .HasOne<Ride>(c => c.Ride)
                .WithMany(r => r.ConductorsList)
                .HasForeignKey(c => c.RideID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Conductors>()
                .HasOne<Employee>(c => c.Conductor)
                .WithMany(e => e.ConductorsList)
                .HasForeignKey(c => c.ConductorID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cars>()
                .HasOne<Ride>(c => c.Ride)
                .WithMany(r => r.CarsList)
                .HasForeignKey(c => c.RideID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cars>()
                .HasOne<Car>(c => c.Car)
                .WithMany(c => c.CarsList)
                .HasForeignKey(c => c.CarID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Journey>()
                .HasOne<Day>(j => j.Day)
                .WithMany(d => d.Journeys)
                .HasForeignKey(j => j.DayID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Journey>()
                .HasOne<Status>(j => j.Status)
                .WithMany(s => s.Journeys)
                .HasForeignKey(j => j.StatusID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Journey>()
                .HasOne<Ride>(j => j.Ride)
                .WithMany(r => r.Journeys)
                .HasForeignKey(j => j.RideID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Journey>()
                .HasOne<Place>(j => j.StartingPlace)
                .WithMany(p => p.Journeys)
                .HasForeignKey(j => j.StartingPlaceID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Journey>()
                .HasOne<Place>(j => j.DestinationPlace)
                .WithMany(p => p.Journeys)
                .HasForeignKey(j => j.DestinationPlaceID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tickets>()
                .HasOne<Ticket>(t => t.Ticket)
                .WithMany(t => t.TicketsList)
                .HasForeignKey(t => t.TicketID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tickets>()
                .HasOne<Journey>(t => t.Journey)
                .WithMany(j => j.TicketsList)
                .HasForeignKey(t => t.JourneyID)
                .OnDelete(DeleteBehavior.SetNull);
        }
        
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Ride> Ride { get; set; }
        public DbSet<Conductors> Conductors { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Day> Day { get; set; }
    }
}