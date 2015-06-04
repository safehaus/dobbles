using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public class AnswerMetadata
    {
        public Guid Id { get; set; }
        public string AnswerValue { get; set; }
    }

    public class Answer
    {
        public Guid Id { get; private set; }
        public string AnswerValue { get; set; }
        public User User { get; set; }
        public string RoomId { get; set; }

        public Answer(User user)
        {
            Id = Guid.NewGuid();
        }
    }
}
