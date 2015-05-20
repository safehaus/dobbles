using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Model;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;

namespace Safehaus.IntranetGaming.DataLayer
{
    public interface IRoomDataLayer
    {
        Task<Room> CreateRoomAsync();
        Task<Room> GetRoomAsync(string roomId);
        Task<Room> AddUserToRoomAsync(string roomId, User user);
        Task<bool> DeleteRoomAsync(string roomId);
    }
}
