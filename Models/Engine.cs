using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Engine
    {
        public Engine()
        {
            Rides = new HashSet<Ride>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool Available { get; set; }

        public virtual ICollection<Ride> Rides { get; set; }
    }
}
