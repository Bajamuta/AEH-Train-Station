using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TrainStation.Models
{
    public partial class Journey
    {
        public Journey()
        {
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        public int ID { get; set; }
        public int DayId { get; set; }
        public int StatusId { get; set; }
        public int RideId { get; set; }
        public int StartingPlaceId { get; set; }
        public DateTime StartingDateTime { get; set; }
        public TimeSpan BreakTimeOnStation { get; set; }
        public TimeSpan FullTimeRide { get; set; }
        public DateTime EndingDateTime { get; set; }
        public decimal TicketBasePrice { get; set; }
        public int DestinationPlaceId { get; set; }

        public virtual Day Day { get; set; }
        public virtual Place DestinationPlace { get; set; }
        public virtual Ride Ride { get; set; }
        public virtual Place StartingPlace { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
