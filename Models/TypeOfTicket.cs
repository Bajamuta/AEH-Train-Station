using System;
using System.Collections.Generic;

#nullable disable

namespace TrainStation.Models
{
    public partial class TypeOfTicket
    {
        public TypeOfTicket()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
