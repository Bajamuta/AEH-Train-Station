using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        public int ID { get; set; }
        public int TypeOfTicketID { get; set; }
        public int Number { get; set; }
        public int CarID { get; set; }
        public DateTime SoldDateTime { get; set; }
        public decimal SoldPrice { get; set; }

        public virtual Car Car { get; set; }
        public virtual TypeOfTicket TypeOfTicket { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
