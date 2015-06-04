using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Responses
{
    public class ChooseAnswerPhaseDetails
    {
        public List<AnswerMetadata> AnswerOptions { get; set; }
        public string Question { get; set; }

        public ChooseAnswerPhaseDetails()
        {
            AnswerOptions = new List<AnswerMetadata>();
        }
    }
}
