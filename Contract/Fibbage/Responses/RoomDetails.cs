using System.Collections.Generic;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class RoomDetails
    {
        public string RoomId { get; set; }
        public IEnumerable<string> UserNames { get; set; }
    }
}
