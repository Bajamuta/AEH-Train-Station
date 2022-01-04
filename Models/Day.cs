using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Day
    {
        public Day()
        {
            Journeys = new HashSet<Journey>();
        }

        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
