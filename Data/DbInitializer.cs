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
            
            var types = new TypeOfTicket[]
            {
                new TypeOfTicket {Name = "sitting", Description = ""},
                new TypeOfTicket {Name = "standing", Description = ""}
            };
            
            var statuses = new Status[]
            {
                new Status{Name = "station", Description = "The train is waiting at the station"},
                new Status {Name = "go", Description = "The train is heading to the station"},
                new Status {Name = "leave", Description = "The train has leave the station"},
                new Status {Name = "end", Description = "The train reached its destination"},
                new Status {Name = "problem", Description = "The train occured an technical issue"},
                new Status {Name = "future", Description = "The journey is in the future"},
            };

            var engines = new Engine[]
            {
                new Engine {Name = "Alice Cooper", ProductionDate = DateTime.Parse("1980-03-26"), Available = true},
                new Engine {Name = "Jane Austin", ProductionDate = DateTime.Parse("1979-09-13"), Available = true},
                new Engine {Name = "Donald Duck", ProductionDate = DateTime.Parse("1999-01-19"), Available = true}
            };

            var cars = new Car[]
            {
                new Car {Name = "Rose", Sitting = 30, Standing = 25, Available = true, ProductionDate = DateTime.Parse("1999-01-01")},
                new Car {Name = "Gilly", Sitting = 28, Standing = 35, Available = true, ProductionDate = DateTime.Parse("1989-09-01")},
                new Car {Name = "Poppy", Sitting = 15, Standing = 20, Available = true, ProductionDate = DateTime.Parse("1979-06-01")},
                new Car {Name = "Mint", Sitting = 32, Standing = 24, Available = true, ProductionDate = DateTime.Parse("1993-05-01")},
                new Car {Name = "Apple", Sitting = 26, Standing = 22, Available = true, ProductionDate = DateTime.Parse("1969-12-01")}
            };
            
            var head = permissions.FirstOrDefault(v => v.Name == "head");
            var conductor = permissions.FirstOrDefault(v => v.Name == "conductor");
            var driver = permissions.FirstOrDefault(v => v.Name == "driver");
            var cashier = permissions.FirstOrDefault(v => v.Name == "cashier");

            var employees = new Employee[]
            {
                new Employee{ Name = "John", Surname = "Smith", BirthDate = DateTime.Parse("1990-09-01"), Permission = head},
                new Employee{ Name = "Alan", Surname = "Tobascco", BirthDate = DateTime.Parse("1970-06-01"), Permission = conductor},
                new Employee{ Name = "Alice", Surname = "Cooper", BirthDate = DateTime.Parse("1968-07-03"), Permission = driver},
                new Employee{ Name = "Monica", Surname = "Belucci", BirthDate = DateTime.Parse("1987-05-12"), Permission = conductor},
                new Employee{ Name = "Bella", Surname = "Pretty", BirthDate = DateTime.Parse("1980-12-01"), Permission = cashier},
                new Employee{ Name = "James", Surname = "Bond", BirthDate = DateTime.Parse("1960-09-13"), Permission = cashier},
            };

            var places = new Place[]
            {
                new Place { Name = "Station", PostalCode = 000, TravelTime = TimeSpan.Parse("0")},
                new Place { Name = "London", PostalCode = 123, TravelTime = TimeSpan.Parse("1:12")},
                new Place { Name = "Warsaw", PostalCode = 254, TravelTime = TimeSpan.Parse("2:35")},
                new Place { Name = "Glasgow", PostalCode = 125, TravelTime = TimeSpan.Parse("0:45")},
                new Place { Name = "Berlin", PostalCode = 389, TravelTime = TimeSpan.Parse("4:18")},
                new Place { Name = "Prague", PostalCode = 111, TravelTime = TimeSpan.Parse("1:58")},
                new Place { Name = "Barcelona", PostalCode = 567, TravelTime = TimeSpan.Parse("3:18")},
            };

            if (!context.Permissions.Any())
            {
                try
                {
                    context.Set<Permission>();
                    context.Permissions.AddRange(permissions);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }
            
            if (!context.Statuses.Any())
            {
                try
                {
                    context.Set<Status>();
                    context.Statuses.AddRange(statuses);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }
            
            if (!context.Engines.Any())
            {
                try
                {
                    context.Set<Engine>();
                    context.Engines.AddRange(engines);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }
            
            if (!context.TypesOfTickets.Any())
            {
                try
                {
                    context.Set<TypeOfTicket>();
                    context.TypesOfTickets.AddRange(types);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }
            
            if (!context.Car.Any())
            {
                try
                {
                    context.Set<Car>();
                    context.Car.AddRange(cars);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }

            if (!context.Places.Any())
            {
                try
                {
                    context.Set<Place>();
                    context.Places.AddRange(places);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }
            
            if (!context.Employees.Any())
            {
                try
                {
                    context.Set<Employee>();
                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error: ", e);
                }
            }

            if (!context.Rides.Any())
            {
                try
                {
                    context.Set<Ride>();
                    context.Add(new Ride
                    {
                        Name = "First Ride",
                        EngineId = context.Engines.FirstOrDefault().ID,
                        DriverId = context.Employees.Where(e => e.PermissionID == driver.ID).FirstOrDefault().ID
                    });
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("error: ", e);
                }
            }

            if (!context.Cars.Any())
            {
                Car car = context.Car.FirstOrDefault();
                Ride ride = context.Rides.FirstOrDefault();
                try
                {
                    context.Set<Cars>();
                    context.Add(
                        new Cars
                        {
                            CarID = car.ID,
                            RideID = ride.ID
                        });
                    context.SaveChanges();
                    try
                    {
                        context.Update(car).Entity.Available = false;
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("error: ", e);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("error: ", e);
                }
            }

            return;
        }
    }
}