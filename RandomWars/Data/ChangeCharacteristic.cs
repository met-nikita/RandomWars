namespace RandomWars.Data
{
    public class ChangeCharacteristic : BaseChange
    {
        //public int ChangeCharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
        public int Value { get; set; }
        public override void Change(Character character, double multiplier)
        {
            switch (Characteristic)
            {
                case Characteristic.CHAR_STRENGTH:
                    character.Strength += (int)(Value * multiplier);
                    break;
                case Characteristic.CHAR_SMARTS:
                    character.Smarts += (int)(Value * multiplier);
                    break;
                case Characteristic.CHAR_HEALTH:
                    character.Health += (int)(Value * multiplier);
                    break;
                default:
                    break;
            }
        }
    }
}
