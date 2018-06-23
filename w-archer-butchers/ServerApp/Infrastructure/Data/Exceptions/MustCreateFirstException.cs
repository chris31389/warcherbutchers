using System;
using System.Runtime.Serialization;

namespace WArcherButchers.ServerApp.Infrastructure.Data.Exceptions
{
    [Serializable]
    public class MustCreateFirstException : Exception
    {
        public MustCreateFirstException()
        {
        }

        public MustCreateFirstException(string message) : base(message)
        {
        }

        public MustCreateFirstException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MustCreateFirstException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}