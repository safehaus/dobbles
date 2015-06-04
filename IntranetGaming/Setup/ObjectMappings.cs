using System.Linq;
using AutoMapper;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;

namespace Safehaus.IntranetGaming.Setup
{
    public class ObjectMappings
    {
        public static void MapObjects()
        {
            Mapper.CreateMap<Room, RoomDetails>()
                .ForMember(
                m => m.UserNames, 
                m => m.MapFrom(f => f.Users.Keys.Select(g => f.Users[g].UserName)));

            Mapper.CreateMap<RoundDetails, GuessRoundResponse>()
                .ForMember(
                    m => m.Question,
                    m => m.MapFrom(f => f.CurrentQuestion.QuestionString))
                .ForMember(
                    m => m.UserNamesAnswered,
                    m => m.MapFrom(f => f.GetUsersNamesAnsered())
                );

            Mapper.CreateMap<Answer, AnswerMetadata>();
            Mapper.CreateMap<RoundDetails, ChooseAnswerPhaseDetails>()
                .ForMember(f => f.AnswerOptions, f => f.MapFrom(g => g.GetAnswers()))
                .ForMember(f => f.Question, f => f.MapFrom(g => g.CurrentQuestion));
        }

    }
}
