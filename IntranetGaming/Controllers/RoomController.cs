using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Contract.Shared;
using Safehaus.IntranetGaming.DataLayer;

namespace Safehaus.IntranetGaming.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        private IRoomDataLayer RoomDataLayer;
        public RoomController(IRoomDataLayer dataLayer)
        {
            RoomDataLayer = dataLayer;
        }

        [HttpGet]
        [ResponseType(typeof(RoomDetails))]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(string id)
        {
            var room = await RoomDataLayer.GetRoomAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<RoomDetails>(room));
        }

        [HttpPut]
        [ResponseType(typeof(RoomDetails))]
        [Route("")]
        public async Task<IHttpActionResult> Put()
        {
            var newRoom = await RoomDataLayer.CreateRoomAsync();
            return Ok( await Task.FromResult(newRoom));
        }

        [HttpPost]
        [ResponseType(typeof(RoomDetails))]
        [Route("{id}")]
        public async Task<IHttpActionResult> Post(string id, [FromBody]AddToRoomRequest request)
        {
            var room = await RoomDataLayer.AddUserToRoomAsync(id, request.User);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<RoomDetails>(room));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var deleteSuccess = await RoomDataLayer.DeleteRoomAsync(id);
            if (!deleteSuccess)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
