using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    [Serializable]
    public class ClientDiscoverableException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ClientDiscoverableException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ClientDiscoverableException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ClientDiscoverableException(string message, HttpStatusCode statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }

        protected ClientDiscoverableException(
            HttpStatusCode statusCode,
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            StatusCode = statusCode;
        }
    }
}
