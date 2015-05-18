using System;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Requests
{
    public class AddToRoomRequest
    {
        public string RoomId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
