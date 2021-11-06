using System;
using System.Linq;
using TrainStation.Models;

namespace TrainStation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{ Name = "John", Surname = "Smith", BirthDate = DateTime.Parse("1990-09-01"), Type = "head"},
            };

            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}