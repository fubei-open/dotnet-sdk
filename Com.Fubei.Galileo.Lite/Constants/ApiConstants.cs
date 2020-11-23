using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Com.Illuminati.Galileo.Constants
{
    public class ApiConstants
    {
        public const int SuccessCode = 200;

        public const string Json = "json";

        public const string Form = "form";

        public const string Md5 = "md5";

        public const string Version10 = "1.0";

        public const string Version20 = "2.0";

        public const string Post = "POST";

        public const string Get = "GET";

        public const string KeyApiconfig = "Storage.ApiConfig";

        public const string Resolve = "Resolve";

        public const string Reject = "Reject";

        public const string ApplicationJson = "application/json; charset=utf-8";

        public const string XFormUrlEncoded = "application/x-www-form-urlencoded; charset=UTF-8";

        public const string FubeiOpenapiHost = "https://shq-api.51fubei.com";

        public const string AppId = "app_id";

        public const string Format = "format";

        public const string SignMethod = "sign_method";

        public const string Method = "method";

        public const string Nonce = "nonce";

        public const string BizContent = "biz_content";

        public const string Version = "version";

        public const string Sign = "sign";

        public const string AccessToken = "access_token";

        public const string JsonTag = "$JSON$";

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
