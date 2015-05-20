using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public class Answer
    {
        public string AnswerValue { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string RoomId { get; set; }
    }
}
