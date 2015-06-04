using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Contract.Shared;

namespace Safehaus.IntranetGaming.Test
{
    public class IntranetGamingClient
    {
        private HttpClient Client;
        public IntranetGamingClient(HttpClient client)
        {
            Client = client;
        }

        #region Room

        public async Task<RoomDetails> GetRoomDetailsAsync(string roomId)
        {
            var response = await Client.GetAsync(string.Format("/api/room/{0}", roomId));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<RoomDetails>();
        }

        public async Task<RoomDetails> CreateNewRoomAsync()
        {
            var response = await Client.PutAsync("/api/room", new StringContent(""));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<RoomDetails>();
        }

        public async Task<RoomDetails> AddUserToRoomAsync(string roomId, AddToRoomRequest addToRoomRequest)
        {
            var response = await Client.PostAsJsonAsync(string.Format("/api/room/{0}", roomId), addToRoomRequest);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<RoomDetails>();
        }

        public async Task DeleteRoomAsync(string roomId)
        {
            await Client.DeleteAsync(string.Format("/api/room/{0}", roomId));
        }

        #endregion


        #region Round Details
        public async Task<GuessRoundResponse> GetGuessesAsync(string roomId)
        {
            var response = await Client.GetAsync(string.Format("/api/rounds/{0}/guesses", roomId));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            } 
            return await response.Content.ReadAsAsync<GuessRoundResponse>();
        }
        public async Task<GuessRoundResponse> GetAnswersAsync(string roomId)
        {
            var response = await Client.GetAsync(string.Format("/api/rounds/{0}/answers", roomId));
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<GuessRoundResponse>();
        }
        #endregion
    }
}
