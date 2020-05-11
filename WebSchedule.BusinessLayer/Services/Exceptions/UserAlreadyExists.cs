using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    [Serializable]
    public class UserAlreadyExistsException : ClientDiscoverableException
    {
        public UserAlreadyExistsException(HttpStatusCode statusCode)
            : base(statusCode)
        {
        }

        public UserAlreadyExistsException(string message, HttpStatusCode statusCode) 
            : base(message, statusCode)
        {
        }

        public UserAlreadyExistsException(string message, HttpStatusCode statusCode, Exception inner) 
            : base(message, statusCode, inner)
        {
        }

        protected UserAlreadyExistsException(
            HttpStatusCode statusCode,
            SerializationInfo info,
            StreamingContext context) 
            : base(statusCode, info, context)
        {
        }
    }
}
