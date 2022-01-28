namespace RandomWars.Data
{
    public class EventReact : Event
    {
        public Characteristic Requirement { get; set; }
        public bool Reflect { get; set; }
        public double Multiplier { get; set; }
    }
}
