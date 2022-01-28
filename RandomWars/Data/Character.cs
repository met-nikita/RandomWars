using System.Drawing;

namespace RandomWars.Data
{
    public abstract class Character
    {
        public int CharacterId { get; set; }
        public string? Name { get; set; }
        public Bitmap? Icon {get; set; }
        public CharacterStatus CharacterStatus { get; set; }
        public int KillCount { get; set; }
        public int Strength { get; set; }
        public int Smarts { get; set; }
        public int Health { get; set; }

    }
}
