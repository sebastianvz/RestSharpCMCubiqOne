using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubiqOneAcces.Helpers
{
    public class Utilities
    {
        public static IRestResponse doRequest(RestRequest request, RestClient client) 
        {
            string message;
            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                if (response.Content != null)
                {
                    message = "Error retrieving response." + response.Content + response.ErrorMessage + response.ErrorException;
                }
                else
                {
                    message = "Error retrieving response.  Check inner details for more info." + response.StatusCode + response.StatusDescription + response.ErrorMessage + response.ErrorException;
                }

                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                message = "NOT FOUND" + response.Content;
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                message = "BAD HEADER. " + response.Content;
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            return response;

        }
    }
}
