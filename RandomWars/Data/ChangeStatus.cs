namespace RandomWars.Data
{
    public class ChangeStatus : IChange
    {
        public CharacterStatus CharacterStatus { get; set; }
        public int Value { get; set; }
        public void Change(Character character)
        {
            if(Value < (int)CharacterStatus.STATUS_MAX)
                character.CharacterStatus = (CharacterStatus)Value;
        }
    }
}
