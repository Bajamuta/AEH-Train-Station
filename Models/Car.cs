using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Car
    {
        public Car()
        {
            Cars = new HashSet<Cars>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        
        [DisplayName("Production's date")]
        public DateTime ProductionDate { get; set; }
        public int Sitting { get; set; }
        public int Standing { get; set; }
        public bool Available { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
