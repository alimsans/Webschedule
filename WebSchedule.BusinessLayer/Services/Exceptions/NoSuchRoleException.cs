using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    [Serializable]
    public class NoSuchRoleException : ClientDiscoverableException
    {
        public NoSuchRoleException(HttpStatusCode statusCode)
            : base(statusCode)
        {
        }

        public NoSuchRoleException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public NoSuchRoleException(string message, HttpStatusCode statusCode, Exception inner)
            : base(message, statusCode, inner)
        {
        }

        protected NoSuchRoleException(
            HttpStatusCode statusCode,
            SerializationInfo info,
            StreamingContext context)
            : base(statusCode, info, context)
        {
        }
    }
}
