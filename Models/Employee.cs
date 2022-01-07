using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Conductors = new HashSet<Conductor>();
            Rides = new HashSet<Ride>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [DisplayName("Birthday")]
        public DateTime BirthDate { get; set; }
        
        [DisplayName("Type")]
        public int PermissionID { get; set; }
        
        [DisplayName("Type")]
        public virtual Permission Permission { get; set; }
        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<Ride> Rides { get; set; }
    }
}
