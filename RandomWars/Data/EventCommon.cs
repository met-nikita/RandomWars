namespace RandomWars.Data
{
    public class EventCommon : Event
    {
        public int Count { get; set; }
        public List<BaseChange>? Changes { get; set; }
    }
}
