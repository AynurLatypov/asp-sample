using System;
using System.Net;

namespace Trade.Exceptions
{
    public class ResponseException : Exception
    {
        public HttpStatusCode Code { get; }
        
        public ResponseException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}