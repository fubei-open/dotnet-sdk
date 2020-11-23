using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Exceptions
{
    public class FubeiSdkException : Exception
    {
        public enum ExceptionType
        {
            Runtime,
            Http,
            Biz
        }

        public override string Message => ToString();

        protected FubeiSdkException(ExceptionType exceptionType, Exception innerException = null) : base("SdkException", innerException)
        {
            this.Type = exceptionType;
        }

        public FubeiSdkException(string msg, Exception innerException = null) : base(msg, innerException)
        {
            this.Type = ExceptionType.Runtime;
        }

        public ExceptionType Type { get; private set; }

    }
}
