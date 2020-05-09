using System;
using System.Runtime.Serialization;

namespace Lab1.Services.Exceptions
{
    [Serializable]
    public class MarkFieldException : Exception
    {
        public MarkFieldException()
        {
        }

        public MarkFieldException(string message) : base(message)
        {
        }

        public MarkFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MarkFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
