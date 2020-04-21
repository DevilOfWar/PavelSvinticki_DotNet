using System;
using System.Runtime.Serialization;

namespace Lab1.Services.Exceptions
{
    [Serializable]
    public class IOSystemException : Exception
    {
        public IOSystemException()
        {
        }

        public IOSystemException(string message) : base(message)
        {
        }

        public IOSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IOSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
