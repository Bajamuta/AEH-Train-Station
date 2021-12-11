using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Journey
    {
        [Key]
        public int ID { get; set; }
        public int DayID { get; set; }
        public Day Day { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public int RideID { get; set; }
        public Ride Ride { get; set; }
        public int StartingPlaceID { get; set; }
        public Place StartingPlace { get; set; }
        // public int DestinationPlaceID { get; set; }
        // public Place DestinationPlace { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDateTime { get; set; }
        public TimeSpan BreakTimeOnStation { get; set; }
        //TODO calculated automatically
        public TimeSpan FullTimeRide { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndingDateTime { get; set; }
        [DataType(DataType.Currency)]
        public decimal TicketBasePrice { get; set; }
        public IList<Tickets> TicketsList { get; set; }
    }
}