using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Exceptions
{
    public class HttpException : FubeiSdkException
    {
        public enum HttpStatus
        {
            None,
            Completed,
            Error,
            TimedOut,
            Aborted,
        }

        public HttpException(int statusCode, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.Body = string.Empty;
            this.Status = HttpStatus.None;
            this.StatusDescription = string.Empty;
        }

        public HttpException(int statusCode, string body, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.Body = body;
            this.Status = HttpStatus.None;
            this.StatusDescription = string.Empty;
        }


        public HttpException(int statusCode, string statusDescription, HttpStatus status, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Status = status;
        }

        public HttpException(int statusCode, string statusDescription, int status, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Status = (HttpStatus) status;
        }

        public HttpException(int statusCode, string statusDescription, HttpStatus status, string body, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Status = status;
            this.Body = body;
        }

        public HttpException(int statusCode, string statusDescription, int status, string body, Exception ex = null) : base(ExceptionType.Http, ex)
        {
            this.HttpStatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Status = (HttpStatus)status;
            this.Body = body;
        }

        public int HttpStatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        public string Body { get; private set; }

        public HttpStatus Status { get; private set; }

        public override string ToString()
        {
            return $"[HttpException]: StatusCode:\"{Status}|{HttpStatusCode}\", StatusDescription:\"{StatusDescription}\", Body: {Body}";
        }
    }
}
