using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Conductor
    {
        [Key]
        public int ID { get; set; }
        public int RideID { get; set; }
        public int ConductorID { get; set; }

        public virtual Employee ConductorEmployee { get; set; }
        public virtual Ride Ride { get; set; }
    }
}
