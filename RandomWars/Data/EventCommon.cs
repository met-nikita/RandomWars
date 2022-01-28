namespace RandomWars.Data
{
    public class EventCommon : Event
    {
        public int Count { get; set; }
        public List<IChange>? Changes { get; set; }
    }
}
