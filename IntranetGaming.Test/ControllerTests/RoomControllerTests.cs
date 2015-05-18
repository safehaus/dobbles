using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Setup;

namespace Safehaus.IntranetGaming.Test.ControllerTests
{
    [TestFixture()]
    public class RoomControllerTests
    {
        [Test()]
        public async Task TestCreateRoom()
        {
            using (var server = TestServer.Create((builder) => new Startup().Configuration(builder, false)))
            {
                var response = await server.HttpClient.PutAsync("/api/room/", new StringContent(String.Empty));
                response.EnsureSuccessStatusCode();

                var roomDetails = await response.Content.ReadAsAsync<RoomDetails>();
                Assert.IsNotNull(roomDetails);
                Assert.AreEqual(0, roomDetails.UserNames.Count());
            }
        }
    }
}
