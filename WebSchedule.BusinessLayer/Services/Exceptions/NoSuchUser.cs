using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    public class NoSuchUserException : ClientDiscoverableException
    {
        public NoSuchUserException(HttpStatusCode statusCode) 
            : base(statusCode)
        {
        }

        public NoSuchUserException(string message, HttpStatusCode statusCode) 
            : base(message, statusCode)
        {
        }

        public NoSuchUserException(string message, HttpStatusCode statusCode, Exception inner) 
            : base(message, statusCode, inner)
        {
        }

        protected NoSuchUserException(HttpStatusCode statusCode, SerializationInfo info, StreamingContext context) 
            : base(statusCode, info, context)
        {
        }
    }
}
