using System;
using System.Net.Http;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Safehaus.IntranetGaming.Setup;

namespace Safehaus.IntranetGaming.Test.ControllerTests
{
    [TestClass]
    public class RoomControllerTests
    {
        [TestMethod]
        public void TestCreateRoom()
        {
            using (var server = TestServer.Create(new Startup().Configuration))
            {
                var result = server.HttpClient.PutAsync("/api/room", null).Result;
            }
        }
    }
}
