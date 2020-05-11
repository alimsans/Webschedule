using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace WebSchedule.BusinessLayer.Services.Exceptions
{
    public class NotEnoughRights : ClientDiscoverableException
    {
        public NotEnoughRights(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public NotEnoughRights(string message, HttpStatusCode statusCode) 
            : base(message, statusCode)
        {
        }

        public NotEnoughRights(string message, HttpStatusCode statusCode, Exception inner) 
            : base(message, statusCode, inner)
        {
        }

        protected NotEnoughRights(HttpStatusCode statusCode, SerializationInfo info, StreamingContext context) 
            : base(statusCode, info, context)
        {
        }
    }
}
