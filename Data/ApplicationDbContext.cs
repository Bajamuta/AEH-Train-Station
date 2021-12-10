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
        
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Ride> Ride { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Day> Day { get; set; }
    }
}