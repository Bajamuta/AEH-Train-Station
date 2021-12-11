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
        
        public IList<Cars> CarsList { get; set; }
        public int DriverID { get; set; }
        public Employee Driver { get; set; }
        
        public IList<Conductors> ConductorsList { get; set; }
        public ICollection<Journey> Journeys { get; set; }
    }
}