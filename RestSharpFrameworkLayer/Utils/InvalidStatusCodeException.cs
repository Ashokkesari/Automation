using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameworkLayer.Utils
{
    public class InvalidStatusCodeException : Exception
    {
        public InvalidStatusCodeException(HttpStatusCode statusCode) : base($"Invalid status code { statusCode}")
        {

        }
    }
}
