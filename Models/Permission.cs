using System.ComponentModel.DataAnnotations;

namespace TrainStation.Models
{
    public class Permission
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}