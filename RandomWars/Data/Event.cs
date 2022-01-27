namespace RandomWars.Data
{
    public class Event
    {
        public string? Text { get; set; }
        public int Count { get; set; }
        public bool IsFinal { get; set; }
        public List<IChange>? Changes { get; set; }
    }
}
