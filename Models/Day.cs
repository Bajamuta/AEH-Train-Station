using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Day
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public ICollection<Journey> Journeys { get; set; }
    }
}