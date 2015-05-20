using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class ChooseAnswerPhaseDetails
    {
        public List<string> AnswerOptions { get; set; }
        public string Question { get; set; }
    }
}
