﻿using CubiqOneAcces.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubiqOne.Controller
{
    public class CubiqOneAccess
    {
        public IRestResponse AccessCubiqOne(string resource, string IpAddress, string method, string parameters = null)
        {
            var recivemethod = (method.ToLower().Equals("post")) ? Method.POST : Method.GET;
            IRestResponse resp;
            //RestClient call request
            RestClient client = new RestClient();
            client.ReadWriteTimeout = 1000;
            client.Timeout = 10000;
            client.BaseUrl = new Uri("http://"+ IpAddress +"/cubiqMiddlewareApi/api/");
            //RestRequest has the whole stuff to consume API
            RestRequest request = new RestRequest(recivemethod);
            request.Parameters.Clear();
            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;
            if (parameters != null)
            {
                request.AddHeader("Accept", "application/json charset=utf-8");
                var json = JObject.Parse(parameters);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }
            var sendIt = Utilities.doRequest(request, client);
            return sendIt;
        }
    }
}

