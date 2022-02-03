namespace RandomWars.Data
{
    public class GameInfo
    {
        public int GameInfoId { get; set; }
        public int Day { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Character? LastActor { get; set; }
        public GameState GameState { get; set; }
    }
}
