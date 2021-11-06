using System;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Type { get; set; }
    }
}