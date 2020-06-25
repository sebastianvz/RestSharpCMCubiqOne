using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CubiqManager.Controller;
using CubiqOne.Controller;

namespace UnitTest
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void TestMethodCubiqManagerAccess()
        {
            CubiqManagerAccess test = new CubiqManagerAccess();
            string resource = "externalapi/getMachines";
            string apiKey = "";
            string method = "get";
            test.AccessCM(resource, apiKey, method);
        }

        [TestMethod]
        public void TestMethodCubiqOneAccess()
        {
            CubiqOneAccess test = new CubiqOneAccess();
            string resource = "getConfigAll";
            string method = "get";
            string ipAddress = "10.8.0.18";
            test.AccessCubiqOne(resource, ipAddress, method);
        }
    }

}