using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;

namespace Safehaus.IntranetGaming.DataLayer.InMemory
{
    public class RoomInMemoryDataLayer : IRoomDataLayer
    {
        private Dictionary<string, Room> Rooms = new Dictionary<string, Room>();
        
        public async Task<Room> CreateRoomAsync()
        {
            var newRoom = new Room();
            return await Task.FromResult(newRoom);
        }

        public async Task<Room> GetRoomAsync(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                return Rooms[roomId];
            }
            return await Task.FromResult(default(Room));
        }

        public async Task<Room> AddUserToRoomAsync(string roomId, User user)
        {
            if (Rooms.ContainsKey(roomId))
            {
                Rooms[roomId].AddUserToRoom(user);
                return await Task.FromResult(Rooms[roomId]);
            }
            return null;
        }

        public async Task<bool> DeleteRoomAsync(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                Rooms.Remove(roomId);
                return true;
            }
            return await Task.FromResult(false);

        }
    }
}
