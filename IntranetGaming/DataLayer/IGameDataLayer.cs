using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;

namespace Safehaus.IntranetGaming.DataLayer
{
    public interface IGameDataLayer
    {
        Task<Game> StartNewGameAsync(string roomId);
        Task<Game> GetGameAsync(string roomId);
    }
}
