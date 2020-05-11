using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : ClientDiscoverableException
    {
        public EntityNotFoundException(HttpStatusCode statusCode)
            : base(statusCode)
        {
        }

        public EntityNotFoundException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public EntityNotFoundException(string message, HttpStatusCode statusCode, Exception inner)
            : base(message, statusCode, inner)
        {
        }

        protected EntityNotFoundException(
            HttpStatusCode statusCode,
            SerializationInfo info,
            StreamingContext context)
            : base(statusCode, info, context)
        {
        }
    }

}
