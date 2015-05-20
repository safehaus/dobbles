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
        public string CorrectAnswer { get; private set; }

        public Question(Guid id, string questionString, string correctAnswer)
        {
            QuestionId = id;
            QuestionString = questionString;
            CorrectAnswer = correctAnswer;
        }
    }
}
