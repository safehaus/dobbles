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
            if (!IsGuessPhaseFinished())
            {
                return new List<string>();
            }
            var results = Answers.Select(e => e.AnswerValue).ToList();
            results.Add(CurrentQuestion.CorrectAnswer);
            return results;
        }
    }
}
