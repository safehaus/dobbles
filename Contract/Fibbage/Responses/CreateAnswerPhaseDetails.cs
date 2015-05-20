using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class CreateAnswerPhaseDetails
    {
        public List<Guid> UserNamesAnswered { get; set; }
        public string Question { get; set; }

        public CreateAnswerPhaseDetails()
        {
            UserNamesAnswered = new List<Guid>();
        }
    }
}
