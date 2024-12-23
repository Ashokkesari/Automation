using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameworkLayer.Utils
{
    public class RestClientUtil
    {
        public static RestClient? _RestClient;

        public static RestRequest? _RestRequest;

        public static RestClient RestClient
        {
            get
            {
                if (_RestClient == null)
                {
                    return new RestClient("http://localhost:3000");
                }
                else
                    return _RestClient;
            }
        }

        public static RestRequest CreateRequest(string resource, Method method, DataFormat dataFormat)
        {
            if (_RestRequest == null)
            {
                return new RestRequest(resource, method);
            }
            else
                return _RestRequest;
        }

        public static RestResponse ExecuteRequest(string resource, string payload, DataFormat dataFormat, Method method)
        {
            return RestClient.Execute
                    (
                        CreateRequest
                        (resource, method, dataFormat)
                        .AddBody(payload)
                    );
        }


        //Get Posts
        public static T? Get<T>(string resource, DataFormat dataFormat, HttpStatusCode expectedCode)
        {
            var response = RestClient.Execute
                    (
                        CreateRequest
                        (resource, Method.Get, dataFormat)
                    );
            if (response.StatusCode != expectedCode)
                throw new InvalidStatusCodeException(response.StatusCode);
            return JsonConvert.DeserializeObject<T>
                (
                    response.Content
                );
        }

        //Create posts
        public static T? Post<T>(string resource, string payload, DataFormat dataFormat, HttpStatusCode httpStatusCode)
        {
            var response = ExecuteRequest(resource, payload, dataFormat, Method.Post);
            if (response.StatusCode != httpStatusCode)
                throw new InvalidStatusCodeException(response.StatusCode);
            return JsonConvert.DeserializeObject<T>
                (
                    response.Content
                );
        }

        //Update posts
        public static T? Put<T>(string resource, string payload, DataFormat dataFormat, HttpStatusCode httpStatusCode)
        {
            var response = ExecuteRequest(resource, payload, dataFormat, Method.Put);
            if (response.StatusCode != httpStatusCode)
                throw new InvalidStatusCodeException(response.StatusCode);
            return JsonConvert.DeserializeObject<T>
                (
                    response.Content
                );
        }

        //Delete Posts
        public static bool Delete(string resource, DataFormat dataFormat, HttpStatusCode expectedCode)
        {
            return RestClient.Execute
                    (
                        CreateRequest
                        (resource, Method.Delete, dataFormat)
                    ).StatusCode.Equals(expectedCode);
        }

       
    }
}
