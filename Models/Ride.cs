using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Ride
    {
        public Ride()
        {
            Cars = new HashSet<Cars>();
            Conductors = new HashSet<Conductor>();
            Journeys = new HashSet<Journey>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int EngineId { get; set; }
        public int DriverId { get; set; }

        public virtual Employee Driver { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual ICollection<Cars> Cars { get; set; }
        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
