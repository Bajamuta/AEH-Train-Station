using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Place
    {
        public Place()
        {
            JourneyDestinationPlaces = new HashSet<Journey>();
            JourneyStartingPlaces = new HashSet<Journey>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public TimeSpan TravelTime { get; set; }

        public virtual ICollection<Journey> JourneyDestinationPlaces { get; set; }
        public virtual ICollection<Journey> JourneyStartingPlaces { get; set; }
    }
}
