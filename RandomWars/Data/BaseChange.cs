namespace RandomWars.Data
{
    public abstract class BaseChange
    {       
        public int Id { get; set; }
        public int CharacterNum { get; set; }
        public abstract void Change(Character character, double multiplier = 1.0);
    }
}
