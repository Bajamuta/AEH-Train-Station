using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        [DisplayName("Type")]
        public int TypeOfTicketID { get; set; }
        public int Number { get; set; }
        
        [DisplayName("Car")]
        public int CarID { get; set; }
        
        [DisplayName("Sold")]
        public DateTime SoldDateTime { get; set; }
        
        [DisplayName("Price")]
        public decimal SoldPrice { get; set; }

        public virtual Car Car { get; set; }
        
        [DisplayName("Type")]
        public virtual TypeOfTicket TypeOfTicket { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
