using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public static class QuestionGenerator
    {
        public static Random r = new Random();
        public static Dictionary<Guid, Question> Questions = new Dictionary<Guid, Question>();

        static QuestionGenerator()
        {
            var guid = Guid.NewGuid(); //.Parse("000011112222-0000-0000-0000-11112222");
            Questions.Add(guid, new Question(guid, "The King Of Prussia has a poodle named _____", "yahoo"));
            guid = Guid.NewGuid(); //.Parse("111111112222-0000-0000-0000-11112222");
            Questions.Add(guid, new Question(guid, "The King Of France has a poodle named _____", "whoopie"));
            guid = Guid.NewGuid(); //.Parse("111111112222-0000-0000-0000-11112222");
            Questions.Add(guid, new Question(guid, "The King Of England has a poodle named _____", "whoopie"));
            guid = Guid.NewGuid(); //.Parse("111111112222-0000-0000-0000-11112222");
            Questions.Add(guid, new Question(guid, "The King Of Germany has a poodle named _____", "whoopie"));
        }
        
        public static Question GetQuestion()
        {
            var questionId = Questions.Keys.ToList()[r.Next(Questions.Keys.Count())];
            return Questions[questionId];
        }

        public static Question GetQuestion(Guid questionId)
        {
            if (!Questions.ContainsKey(questionId))
            {
                throw new ArgumentException(string.Format("Bad Question Id: {0}", questionId), "questionId");
            }
            return Questions[questionId];
        }
    }
}
