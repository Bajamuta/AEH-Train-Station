using System;
using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
        public int Number { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        [DataType(DataType.Date)]
        public DateTime SoldDateTime { get; set; }
        [DataType(DataType.Currency)]
        public decimal SoldPrice { get; set; }
    }
}