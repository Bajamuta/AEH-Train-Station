using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainStation.Models;

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
        
        public DbSet<TrainStation.Models.Employee> Employee { get; set; }
    }
}