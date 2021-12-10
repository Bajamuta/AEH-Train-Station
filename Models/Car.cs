using System;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date of production")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        public int Sitting { get; set; }
        public int Standing { get; set; }
        public Boolean Available { get; set; }
    }
}