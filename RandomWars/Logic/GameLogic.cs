using RandomWars.Data;

namespace RandomWars.Logic
{
    public class GameLogic
    {
        List<Character> characterList;
        List<EventAttack> eventsAttack;
        List<EventCommon> eventsCommon;
        List<EventReact> eventsReact;
        GameInfo gameInfo;
        Random random = new Random();

        public GameLogic(int gameInfoId)
        {
            using (GameContext db = new GameContext())
            {
                characterList = db.Characters.Where(c => c.GameInfo.GameInfoId == gameInfoId).ToList();
                eventsAttack = db.EventAttacks.ToList();
                eventsCommon = db.EventCommons.ToList();
                eventsReact = db.EventReactes.ToList();
                gameInfo = db.GameInfo.Where(c => c.GameInfoId == gameInfoId).Last();
            }
        }

        public GameLogic()
        {
            using (GameContext db = new GameContext())
            {
                gameInfo = new GameInfo() { GameState = GameState.STATE_CREATING };
                db.GameInfo.Add(gameInfo);
                db.SaveChanges();
                characterList = new List<Character>();
                eventsAttack = db.EventAttacks.ToList();
                eventsCommon = db.EventCommons.ToList();
                eventsReact = db.EventReactes.ToList();
            }
        }

        public GameState GetState()
        {
            return gameInfo.GameState;
        }
        public void SetState(GameState gameState)
        {
            gameInfo.GameState = gameState;
        }

        private List<Character> GetAliveCharacters()
        {
            return characterList.Where(c => c.CharacterStatus == CharacterStatus.STATUS_ALIVE).ToList();
        }

        private (List<Character>, string) ProcessRandomCommonEvent()
        {
            EventCommon commonEvent = eventsCommon[random.Next(eventsCommon.Count)];
            List<Character> characters = GetAliveCharacters().OrderBy(x => random.Next()).Take(commonEvent.Count).ToList();
            commonEvent.Changes.ForEach(x => x.Change(characters[x.CharacterNum]));
            string text = commonEvent.Text;
            for (int i = 0; i < characters.Count; i++)
            {
                text = text.Replace("%" + i.ToString(), characters[i].Name);
            }
            return (characters,text);
        }

        private (Character,Character,string,string) ProcessRandomFinalEvent()
        {
            EventAttack attackEvent = eventsAttack[random.Next(eventsAttack.Count)];
            EventReact reactEvent;
            List<Character> characters = GetAliveCharacters();
            Character attacker;
            Character attacked;
            if (gameInfo.LastActor == characters[0])
            {
                attacker = characters[1];
                attacked = characters[0];
            }
            else
            {
                attacker = characters[0];
                attacked = characters[1];
            }
            int maxIter = 50;
            while (true)
            {
                reactEvent = eventsReact[random.Next(eventsReact.Count)];
                bool doBreak = false;
                switch (reactEvent.Requirement)
                {
                    case Characteristic.CHAR_HEALTH:
                        if (attacked.Health >= attacker.Health)
                            doBreak = true;
                        break;
                    case Characteristic.CHAR_STRENGTH:
                        if (attacked.Strength >= attacker.Strength)
                            doBreak = true;
                        break;
                    case Characteristic.CHAR_SMARTS:
                        if (attacked.Smarts >= attacker.Smarts)
                            doBreak = true;
                        break;
                    default:
                        doBreak = true;
                        break;
                }
                if (doBreak || maxIter-- < 0)
                    break;
            }
            gameInfo.LastActor = attacker;
            attackEvent.Changes.ForEach(x => x.Change(reactEvent.Reflect ? attacker : attacked, reactEvent.Multiplier));
            return (attacker,attacked,attackEvent.Text.Replace("%0",attacker.Name), reactEvent.Text.Replace("%0", attacked.Name));
        }
    }
}
