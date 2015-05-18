using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Setup;

namespace Safehaus.IntranetGaming.Test.ControllerTests
{
    [TestClass]
    public class RoomControllerTests
    {
        [TestMethod]
        public async Task TestCreateRoom()
        {
            using (var server = TestServer.Create(new Startup().Configuration))
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
