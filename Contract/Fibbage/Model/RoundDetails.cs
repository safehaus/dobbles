using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public class RoundDetails
    {
        private int NumberOfUsers;
        public string RoomId { get; set; }
        public List<Answer> Answers { get; set; }

        public RoundDetails(int numberUsers, string roomId)
        {
            NumberOfUsers = numberUsers;
            RoomId = roomId;
            Answers = new List<Answer>();
        }

        public bool IsRoundFinished()
        {
            return Answers.Count() == NumberOfUsers;
        }

        public IEnumerable<string> UsersNamesAnsered()
        {
            return Answers.Select(e => e.UserName);
        }

        public bool HasUserAnswered(User user)
        {
            return Answers.FirstOrDefault(a => a.UserId == user.UserId) == null;
        }

        public void AddAnswer(Answer answer)
        {
            var existingAnswer = Answers.FirstOrDefault(a => a.UserId == answer.UserId);
            if (existingAnswer == null)
            {
                Answers.Add(answer);
            }
        }

        public IEnumerable<string> GetAnswers()
        {
            if (!IsRoundFinished())
            {
                return new List<string>();
            }
            return Answers.Select(e => e.AnswerValue);
        }
    }
}
