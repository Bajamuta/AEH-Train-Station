using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int PermissionID { get; set; }
        public Permission Type { get; set; }
        
        public IList<Conductors> ConductorsList { get; set; }
        public ICollection<Ride> Rides { get; set; }
        
    }
}