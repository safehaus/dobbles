using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.DataLayer.InMemory;

namespace Safehaus.IntranetGaming.Test
{
    [TestFixture()]
    public class GameLogicTests
    {
        [Test()]
        public async Task TestGame()
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = "X"
                },
                new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = "Y"
                }
            };

            var roomDL = new RoomInMemoryDataLayer();
            var gameDL = new GameInMemoryDataLayer(roomDL);

            var newRoom = await roomDL.CreateRoomAsync();

            foreach (var user in users)
            {
                await roomDL.AddUserToRoomAsync(newRoom.RoomId, user);
            }

            var game = await gameDL.StartNewGameAsync(newRoom.RoomId);




        }
    }
}
