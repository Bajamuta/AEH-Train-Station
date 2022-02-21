using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Status")]
        public int StatusId { get; set; }
        
        [DisplayName("Ride")]
        public int RideId { get; set; }
        
        [DisplayName("Start")]
        public int StartingPlaceId { get; set; }
        
        [DisplayName("Start at")]
        public DateTime StartingDateTime { get; set; }
        
        [DisplayName("Break")]
        public TimeSpan BreakTimeOnStation { get; set; }
        
        [DisplayName("Time")]
        public TimeSpan FullTimeRide { get; set; }
        
        [DisplayName("Ends at")]
        public DateTime EndingDateTime { get; set; }
        
        [DisplayName("Base Price")]
        public decimal TicketBasePrice { get; set; }
        
        [DisplayName("Destination")]
        public int DestinationPlaceId { get; set; }

        [DisplayName("Destination")]
        public virtual Place DestinationPlace { get; set; }
        public virtual Ride Ride { get; set; }
        
        [DisplayName("Start")]
        public virtual Place StartingPlace { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }

        public TimeSpan CalculateFullTime()
        {
            return StartingPlace.TravelTime + BreakTimeOnStation + DestinationPlace.TravelTime;
        }

        public DateTime CalculateEndTime()
        {
            return StartingDateTime + FullTimeRide;
        }

        public TimeSpan CalculateBreakTime(int temp)
        {
            TimeSpan br;

            if (temp < 10)
            {
                br = TimeSpan.Parse("00:0" + temp);
            }
            else
            {
                br = TimeSpan.Parse("00:" + temp);
            }

            return br;
        }
    }
}
