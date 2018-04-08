using System;
using System.Runtime.Serialization;

namespace WArcherButchers.ServerApp.Infrastructure.Data.Exceptions
{

        [Serializable]
        public class LocalEntitiesNotSavedException : Exception
        {
            public LocalEntitiesNotSavedException()
            {
            }

            public LocalEntitiesNotSavedException(string message) : base(message)
            {
            }

            public LocalEntitiesNotSavedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected LocalEntitiesNotSavedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
}