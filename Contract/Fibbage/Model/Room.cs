using System;
using System.Collections.Generic;
using Safehaus.IntranetGaming.Contract.Fibbage.Utilities;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public class Room
    {
        private static Random r = new Random();
        public string RoomId { get; private set; }
        public Dictionary<Guid, User> Users { get; set; }

        public Room()
        {
            RoomId = StringUtilities.GetRandomString(4);
            Users = new Dictionary<Guid, User>();
        }

        public void AddUserToRoom(User u)
        {
            if (!Users.ContainsKey(u.UserId))
            {
                Users.Add(u.UserId, u);
            }
        }

    }
}
