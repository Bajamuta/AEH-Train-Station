using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Status
    {
        public Status()
        {
            Journeys = new HashSet<Journey>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
