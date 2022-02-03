namespace RandomWars.Data
{
    public class ChangeStatus : BaseChange
    {
        //public int ChangeStatusId { get; set; }
        public CharacterStatus CharacterStatus { get; set; }
        public int Value { get; set; }
        public override void Change(Character character, double multiplier)
        {
            if(Value < (int)CharacterStatus.STATUS_MAX && Value != (int)CharacterStatus.STATUS_UNDEFINED)
                character.CharacterStatus = (CharacterStatus)Value;
        }
    }
}
