using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Com.Illuminati.Galileo.Exceptions
{
    public class BizException : FubeiSdkException
    {
        public BizException(int errCode, string errMsg) : base(ExceptionType.Biz)
        {
            this.ErrCode = errCode.ToString();
            this.ErrMsg = errMsg;
        }

        public BizException(int errCode, string subCode, string errMsg, object obj) : base(ExceptionType.Biz)
        {
            this.ErrCode = errCode.ToString();
            this.ErrMsg = errMsg;
            this.SubCode = subCode;
            this.ReturnObject = obj;
        }

        public BizException(string errCode, string errMsg) : base(ExceptionType.Biz)
        {
            this.ErrCode = errCode;
            this.ErrMsg = errMsg;
        }

        public string ErrCode { get; }

        public string SubCode { get; }

        public string ErrMsg { get; }

        public object ReturnObject { get; }

        public override string ToString()
        {
            return $"[BizException] ErrCode:\"{ErrCode}\" ErrMsg:\"{ErrMsg}\"";
        }

        public override string Message => ToString();
    }
}
