using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Place
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        public TimeSpan TravelTime { get; set; }
        
        public ICollection<Journey> JourneysStarting { get; set; }
        public ICollection<Journey> JourneysDestinations { get; set; }
    }
}