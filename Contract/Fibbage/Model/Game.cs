using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public enum GameState
    {
        NotStarted,
        InProgress,
        Finished
    }

    public class Game
    {
        public int RoundNumber { get; private set; }
        public Guid CurrentQuestion { get; set; }
        public GameState GameState { get; set; }
        
        public Game()
        {
            GameState = GameState.NotStarted;
            RoundNumber = 0;
        }

        public void Start(Room room)
        {
            RoundNumber = 1;
            GameState = Model.GameState.InProgress;
        }

        public string GetQuestion()
        {
            return Questions[RoundNumber];
        }
    }
}
