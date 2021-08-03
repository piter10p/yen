using System;
using System.Runtime.Serialization;

namespace Yen.Exceptions
{
    public abstract class YenException : Exception
    {
        protected YenException()
        {
        }

        protected YenException(string message) : base(message)
        {
        }

        protected YenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected YenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
