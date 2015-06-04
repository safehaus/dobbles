using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.DataLayer;

namespace Safehaus.IntranetGaming.Controllers
{
    [RoutePrefix("api/rounds/{id}")]
    public class RoundController : ApiController
    {
        private IGameDataLayer GameDL;
        public RoundController(IGameDataLayer gameDL)
        {
            GameDL = gameDL;
        }

        [HttpGet]
        [Route("guesses")]
        public async Task<IHttpActionResult> GetGuesses(string id)
        {
            var game = await GameDL.GetGameAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            var roundDetails = Mapper.Map<GuessRoundResponse>(game.CurrentRoundDetails);
            return Ok(roundDetails);
        }

        [HttpGet]
        [Route("answers")]
        public async Task<IHttpActionResult> GetAnswers(string id)
        {
            var game = await GameDL.GetGameAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
