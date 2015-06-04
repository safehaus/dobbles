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
    public class RoundControllerTests
    {
        [Test()]
        public async Task TestCreateRound()
        {
            using (var server = TestServer.Create((builder) => new Startup().Configuration(builder, false)))
            {
                var response = await server.HttpClient.GetAsync("/api/rounds/ABCD/guesses");
                response.EnsureSuccessStatusCode();

                var roomDetails = await response.Content.ReadAsAsync<RoomDetails>();
                Assert.IsNotNull(roomDetails);
                Assert.AreEqual(0, roomDetails.UserNames.Count());
            }
        }
    }
}
