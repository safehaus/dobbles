using System.Linq;
using AutoMapper;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;

namespace Safehaus.IntranetGaming.Setup
{
    public static class ObjectMappings
    {
        public static void MapObjects()
        {
            Mapper.CreateMap<Room, RoomDetails>()
                .ForMember(
                m => m.UserNames, 
                m => m.MapFrom(f => f.Users.Keys.Select(g => f.Users[g].UserName)));
        }
    }
}
