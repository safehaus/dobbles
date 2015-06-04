using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class GuessRoundResponse
    {
        public List<string> UserNamesAnswered { get; set; }
        public string Question { get; set; }

        public GuessRoundResponse()
        {
            UserNamesAnswered = new List<string>();
        }
    }
}
