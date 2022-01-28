namespace RandomWars.Data
{
    public class CharacteristicChange : IChange
    {
        public int CharacteristicChangeId { get; set; }
        public Characteristic Characteristic { get; set; }
        public int Value { get; set; }
        public void Change(Character character)
        {
            switch (Characteristic)
            {
                case Characteristic.CHAR_STRENGTH:
                    character.Strength += Value;
                    break;
                case Characteristic.CHAR_SMARTS:
                    character.Smarts += Value;
                    break;
                case Characteristic.CHAR_HEALTH:
                    character.Health += Value;
                    break;
                default:
                    break;
            }
        }
    }
}
