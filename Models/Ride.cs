using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Ride
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int EngineID { get; set; }
        public Engine Engine { get; set; }
        public ICollection<Car> Cars { get; set; }
        public int DriverID { get; set; }
        public Employee Driver { get; set; }
        public ICollection<Employee> Conductors { get; set; }
    }
}