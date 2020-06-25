using CubiqOneAcces.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace CubiqManager.Controller
{
    public class CubiqManagerAccess
    {
        public IRestResponse AccessCM(string resource, string ApiKey, string method, object parameters = null)
        {
            var recivemethod = (method.ToLower().Equals("post")) ? Method.POST : Method.GET;
            IRestResponse resp;
            //RestClient call request
            RestClient client = new RestClient();
            client.ReadWriteTimeout = 1000;
            client.Timeout = 10000;
            client.BaseUrl = new Uri("http://cubiq.mekagroupcol.com/");
            //RestRequest has the whole stuff to consume API
            RestRequest request = new RestRequest(recivemethod);
            request.Parameters.Clear();
            request.AddHeader("auth", ApiKey);
            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;
            if (parameters != null)
            {
                request.AddHeader("Accept", "application/json charset=utf-8");
                var json = JsonConvert.SerializeObject(parameters);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }
            var  sendIt= Utilities.doRequest(request, client);
            return sendIt;
        }
    }
}
