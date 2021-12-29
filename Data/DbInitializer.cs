using System;
using System.Linq;
using TrainStation.Models;

namespace TrainStation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any employees.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var permissions = new Permission[]
            {
                new Permission {Name = "head", Description = ""},
                new Permission {Name = "conductor", Description = ""},
                new Permission {Name = "driver", Description = ""},
                new Permission {Name = "cashier", Description = ""}
            };
            context.Permission.AddRange(permissions);

            var types = new Models.Type[]
            {
                new Models.Type {Name = "sitting", Description = ""},
                new Models.Type {Name = "standing", Description = ""}
            };
            
            context.Type.AddRange(types);

            var head = permissions.FirstOrDefault(v => v.Name == "head");

            var employees = new Employee[]
            {
                new Employee{ Name = "John", Surname = "Smith", BirthDate = DateTime.Parse("1990-09-01"), Type = head},
            };
            
            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}