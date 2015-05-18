using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;

namespace Safehaus.IntranetGaming.Controllers
{
    public class RoomController : ApiController
    {
        private static Dictionary<string, Room> GameToUserMapping = new Dictionary<string, Room>();
        
        [HttpGet]
        [ResponseType(typeof(RoomDetails))]
        public IHttpActionResult Get(string id)
        {
            if (!GameToUserMapping.ContainsKey(id))
            {
                return NotFound();
            }
            return Ok(Mapper.Map<RoomDetails>(GameToUserMapping[id]));
        }

        [HttpPut]
        [ResponseType(typeof(RoomDetails))]
        public async Task<IHttpActionResult> Put()
        {
            var newRoomDeatils = new Room();
            return Ok( await Task.FromResult(newRoomDeatils));
        }

        [HttpPost]
        [ResponseType(typeof(RoomDetails))]
        public IHttpActionResult Post(string id, [FromBody]AddToRoomRequest request)
        {
            if (!GameToUserMapping.ContainsKey(id))
            {
                return NotFound();
            }
            var user = new User()
            {
                UserId = request.UserId,
                UserName = request.UserName
            };
            GameToUserMapping[id].AddUserToRoom(user);
            return Ok(Mapper.Map<RoomDetails>(GameToUserMapping[id]));
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (!GameToUserMapping.ContainsKey(id))
            {
                return NotFound();
            }
            GameToUserMapping.Remove(id);
            return Ok();
        }
    }
}
