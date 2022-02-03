namespace RandomWars.Data
{
    public abstract class BaseChange
    {       
        public int Id { get; set; }
        public abstract void Change(Character character);
    }
}
