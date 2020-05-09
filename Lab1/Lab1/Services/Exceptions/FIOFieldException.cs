using System;
using System.Runtime.Serialization;

namespace Lab1.Services.Exceptions
{
    [Serializable]
    public class FIOFieldException : Exception
    {
        public FIOFieldException()
        {
        }

        public FIOFieldException(string message) : base(message)
        {
        }

        public FIOFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FIOFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
