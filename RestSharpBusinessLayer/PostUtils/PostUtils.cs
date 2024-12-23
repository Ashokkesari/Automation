using Newtonsoft.Json;
using RestSharp;
using RestSharpFrameworkLayer.Utils;
using System.Net;

namespace RestSharpBusinessLayer.PostUtils
{
    public class PostUtils
    {

        //Get
        public static TestData Get(string id, HttpStatusCode httpStatusCode)
        {
            return RestClientUtil.Get<TestData>("posts/" + id, DataFormat.Json, httpStatusCode);
        }


        //Create
        public static TestData Post(string id, string title, int views, HttpStatusCode httpStatusCode)
        {
            return RestClientUtil.Post<TestData>
            (
                 "posts", CreatePostRequestBody(id, title, views),
                 DataFormat.Json, httpStatusCode
                );
        }

        //put
        public static TestData Put(string id, string title, int views, HttpStatusCode httpStatusCode)
        {
            return RestClientUtil.Put<TestData>
                (
                 "posts/" + id, CreatePostRequestBody(id, title, views),
                 DataFormat.Json, httpStatusCode
                );
        }

        //Delete
        public static bool DeletePost(string id, HttpStatusCode httpStatusCode)
        {
            return RestClientUtil.Delete("posts/" + id, DataFormat.Json, httpStatusCode);
        }


        public static string CreatePostRequestBody(string id, string title, int views)
        {
            TestData data = new()
            {
                id = id,
                title = title,
                views = views
            };

            return JsonConvert.SerializeObject(data);
        }
    }

}
