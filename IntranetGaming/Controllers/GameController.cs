using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.DataLayer;

namespace Safehaus.IntranetGaming.Controllers
{
    public class GameController : ApiController
    {
        public static Dictionary<string, Game> Games = new Dictionary<string, Game>();
        public IGameDataLayer GameDataLayer;
        public IRoomDataLayer RoomDataLayer;

        public GameController(IGameDataLayer gameDataLayer, IRoomDataLayer roomDataLayer)
        {
            GameDataLayer = gameDataLayer;
            RoomDataLayer = roomDataLayer;
        }

        [HttpGet]
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (Games.ContainsKey(id))
            {
                return Ok(await GameDataLayer.GetGame(id));
            }
            return NotFound();
        }

        [HttpPut]
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> Put(string id)
        {
            var room = await RoomDataLayer.GetRoomAsync(id);
            if (room == null)
            {
                return BadRequest("RoomId is invalid");
            }

            if (!Games.ContainsKey(id))
            {
                Games.Add(id, new Game(room));
            }
            return Ok(Games[id]);
        }
    }
}
