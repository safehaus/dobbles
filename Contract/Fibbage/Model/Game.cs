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
        private Room RoomDetails { get; set; }
        public int RoundNumber { get; private set; }
        public GameState GameState { get; set; }
        public Dictionary<Guid, int> Score { get; set; }

        public RoundDetails CurrentRoundDetails { get; set; }
        
        public Game(Room room)
        {
            GameState = GameState.NotStarted;
            RoundNumber = 0;
            RoomDetails = room;
            Score = new Dictionary<Guid, int>();
            foreach (var user in room.Users)
            {
                Score.Add(user.Key, 0);
            }
            Start();
        }

        private void Start()
        {
            GameState = Model.GameState.InProgress;
            AdvanceRound();
        }

        public void AdvanceRound()
        {
            RoundNumber++;
            CurrentRoundDetails = new RoundDetails(RoomDetails.Users.Count, RoomDetails.RoomId);
        }


        public RoundDetails GetCurrentRoundDetails()
        {
            return CurrentRoundDetails;
        }
    }
}
