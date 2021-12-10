using System;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Engine
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        public Boolean Available { get; set; }
    }
}