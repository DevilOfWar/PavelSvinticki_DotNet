using System;
using System.Runtime.Serialization;

namespace Lab1.Services.Exceptions
{
    [Serializable]
    public class FieldNameException : Exception
    {
        public FieldNameException()
        {
        }

        public FieldNameException(string message) : base(message)
        {
        }

        public FieldNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FieldNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
