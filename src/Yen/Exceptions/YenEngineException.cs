using System;
using System.Runtime.Serialization;

namespace Yen.Exceptions
{
    public abstract class YenEngineException : Exception
    {
        protected YenEngineException()
        {
        }

        protected YenEngineException(string message) : base(message)
        {
        }

        protected YenEngineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected YenEngineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
