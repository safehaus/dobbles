using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;

namespace Safehaus.IntranetGaming.DataLayer.InMemory
{
    public class GameInMemoryDataLayer : IGameDataLayer
    {
        private readonly Dictionary<string, Game> Games = new Dictionary<string, Game>();
        private IRoomDataLayer RoomDataLayer;

        public GameInMemoryDataLayer(IRoomDataLayer roomDataLayer)
        {
            RoomDataLayer = roomDataLayer;
        }

        public async Task<Game> StartNewGameAsync(string roomId)
        {
            var room = await RoomDataLayer.GetRoomAsync(roomId);
            if (room == null)
            {
                return null;
            }
            if (!Games.ContainsKey(roomId))
            {
                Games.Add(roomId, new Game(room));
            }
            return Games[roomId];
        }

        public async Task<Game> GetGame(string roomId)
        {
            if (!Games.ContainsKey(roomId))
            {
                return null;
            }
            return await Task.FromResult(Games[roomId]);
        }

        public async Task<RoundDetails> GetRoundDetails(string roomId)
        {
            if (!Games.ContainsKey(roomId))
            {
                return null;
            }
            var game = Games[roomId];
            return await Task.FromResult(game.GetCurrentRoundDetails());
        }

        public async Task AdvanceRound(string roomId)
        {
            if (!Games.ContainsKey(roomId))
            {
                return;
            }
            await Task.Run(() => Games[roomId].AdvanceRound());
        }
    
    
    }
}
