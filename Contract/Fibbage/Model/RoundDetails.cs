using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Model
{
    public enum RoundState
    {
        CreateGuessPhase,
        AnswerPhase
    }

    public class RoundDetails
    {
        public RoundState RoundState { get; set; }
        private int NumberOfUsers;
        public string RoomId { get; set; }
        public Question CurrentQuestion { get; set; }
        public List<Answer> Answers { get; set; }

        public RoundDetails(int numberUsers, string roomId)
        {
            RoundState = RoundState.CreateGuessPhase;
            NumberOfUsers = numberUsers;
            RoomId = roomId;
            Answers = new List<Answer>();
            CurrentQuestion = QuestionGenerator.GetQuestion();
        }

        public bool IsGuessPhaseFinished()
        {
            return Answers.Count() == NumberOfUsers;
        }

        public IEnumerable<string> GetUsersNamesAnsered()
        {
            return Answers.Select(e => e.User.UserName);
        }

        public bool HasUserAnswered(User user)
        {
            return Answers.Any(a => a.User.UserId == user.UserId);
        }

        public void AddAnswer(Answer answer)
        {
            var existingAnswer = Answers.FirstOrDefault(a => a.User.UserId == answer.User.UserId);
            if (existingAnswer == null)
            {
                Answers.Add(answer);
            }
        }

        public IEnumerable<Answer> GetAnswers()
        {
            if (!IsGuessPhaseFinished())
            {
                return new List<Answer>();
            }
            var results = Answers.ToList();
            results.Add(CurrentQuestion.CorrectAnswer);
            return results;
        }
    }
}
