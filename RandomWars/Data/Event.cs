namespace RandomWars.Data
{
    public abstract class Event
    {
        public int EventId { get; set; }
        public string? Text { get; set; }
    }
}
