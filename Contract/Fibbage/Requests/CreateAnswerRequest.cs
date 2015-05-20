using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Requests
{
    public class CreateAnswerRequest
    {
        public Guid UserId { get; set; }
        public string Answer { get; set; }
    }
}
