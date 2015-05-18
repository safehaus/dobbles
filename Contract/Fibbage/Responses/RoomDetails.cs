using System.Collections.Generic;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class RoomDetails
    {
        public string RoomId { get; set; }
        public IEnumerable<string> UserNames { get; set; }

        public RoomDetails()
        {
            UserNames = new List<string>();
        }
    }
}
