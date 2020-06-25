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
            CubiqManagerAccess test1 = new CubiqManagerAccess();
            string resource = "externalapi/getMachines";
            string apiKey = "CcGdrJhmt0FWzFPiBJAqsrbqJ8n4FI8ngmFaf6WwGod";
            string method = "get";
            test1.AccessCM(resource, apiKey, method);
        }

        [TestMethod]
        public void TestMethodCubiqManagerAccessJson()
        {
            CubiqManagerAccess test3 = new CubiqManagerAccess();
            string resource = "externalapi/getLatestMeasures";
            string apiKey = "CcGdrJhmt0FWzFPiBJAqsrbqJ8n4FI8ngmFaf6WwGod";
            string method = "post";
            string parameter = "{\"machine\":\"63C6-2FEE-DEA0-DF2F-E92E-9FF3-6F44-0000\",\"limit\":1}";
            test3.AccessCM(resource, apiKey, method, parameter);
        }

        [TestMethod]
        public void TestMethodCubiqOneAccess()
        {
            CubiqOneAccess test2 = new CubiqOneAccess();
            string resource = "getConfigAll";
            string method = "get";
            string ipAddress = "10.8.0.18";
            test2.AccessCubiqOne(resource, ipAddress, method);
        }

        [TestMethod]
        public void TestMethodCubiqOneAccessJson()
        {
            CubiqOneAccess test4 = new CubiqOneAccess();
            string resource = "getConfigAll";
            string method = "get";
            string ipAddress = "10.8.0.18";
            string parameter = "get";
            test4.AccessCubiqOne(resource, ipAddress, method, parameter);
        }


    }

}