using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public class Question
    {
        public Guid QuestionId { get; private set; }
        public string QuestionString { get; private set; }

        public Question(Guid id, string questionString)
        {
            QuestionId = id;
            QuestionString = questionString;
        }
    }
}
