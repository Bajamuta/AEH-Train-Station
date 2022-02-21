namespace TrainStation.Models
{
    public class TempCar
    {
        public TempCar()
        {
            
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int AllSitting { get; set; }
        public int LeftSitting { get; set; }
        public int AllStanding { get; set; }
        public int LeftStanding { get; set; }
    }
}