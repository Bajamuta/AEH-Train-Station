using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Tickets
    {
        [Key]
        public int ID { get; set; }
        
        [DisplayName("Ticket")]
        public int TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }
        
        [DisplayName("Journey")]
        public int JourneyID { get; set; }
        public virtual Journey Journey { get; set; }
    }
}