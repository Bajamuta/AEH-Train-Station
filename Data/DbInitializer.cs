using System;
using System.Linq;
using TrainStation.Models;

namespace TrainStation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TrainStationContext context)
        {
            
            var permissions = new Permission[]
            {
                new Permission {Name = "head", Description = ""},
                new Permission {Name = "conductor", Description = ""},
                new Permission {Name = "driver", Description = ""},
                new Permission {Name = "cashier", Description = ""}
            };
            var types = new Models.Type[]
            {
                new Models.Type {Name = "sitting", Description = ""},
                new Models.Type {Name = "standing", Description = ""}
            };
            var headID = permissions.FirstOrDefault(v => v.Name == "head").ID;

            var employees = new Employee[]
            {
                new Employee{ Name = "John", Surname = "Smith", BirthDate = DateTime.Parse("1990-09-01"), PermissionID = headID},
            };
            
            // Look for any employees.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }
            
            if (context.Permission.Any())
            {
                return;
            }

            context.Permission.AddRange(permissions);
            context.SaveChanges();
            context.Type.AddRange(types);
            context.SaveChanges();
            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}