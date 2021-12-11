using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Cars
    {
        [Key]
        public int ID { get; set; }
        public int RideID { get; set; }
        public Ride Ride { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}