using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Conductors
    {
        [Key]
        public int ID { get; set; }
        public int RideID { get; set; }
        public Ride Ride { get; set; }
        public int ConductorID { get; set; }
        public Employee Conductor { get; set; }
    }
}