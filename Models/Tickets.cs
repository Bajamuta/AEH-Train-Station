using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Tickets
    {
        [Key]
        public int ID { get; set; }
        public int TicketID { get; set; }
        public Ticket Ticket { get; set; }
        public int JourneyID { get; set; }
        public Journey Journey { get; set; }
    }
}