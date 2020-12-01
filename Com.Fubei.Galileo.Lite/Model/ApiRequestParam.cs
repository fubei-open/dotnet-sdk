using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Utils;

namespace Com.Illuminati.Galileo.Model
{
    public class ApiRequestParam
    {
        public ApiRequestParam()
        {
            this.Nonce = RandomStringUtil.NewRandomString(16);
            this.Format = ApiConstants.Json;
            this.SignMethod = ApiConstants.Md5;
        }

        public ApiRequestParam(ApiAttribute attr)
        {
            this.Nonce = RandomStringUtil.NewRandomString(16);
            this.Method = attr.Method;
            this.SignMethod = attr.SignMethod;
            this.Format = attr.Format;
            this.Version = attr.Version;
        }

        public string VendorSn { get; set; }

        public string AppId { get; set; }

        public string Format { get; set; }

        public string SignMethod { get; set; }

        public string Method { get; set; }

        public string Signature { get; set; }

        public string Nonce { get; set; }

        public string Version { get; set; }

        public string BizContent { get; set; }

        public string Resource { get; set; } = string.Empty;
    }
}


