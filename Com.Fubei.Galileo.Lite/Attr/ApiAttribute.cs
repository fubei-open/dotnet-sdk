using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Constants;

namespace Com.Illuminati.Galileo.Attr
{
    /// <summary>
    /// 付呗Api接口注解
    /// </summary>
    public class ApiAttribute : Attribute
    {
        /// <summary>
        /// 调用方法
        /// </summary>
        public string Method { get; set; }

        public virtual string Format { get; set; } = ApiConstants.Json;

        public string SignMethod { get; set; } = ApiConstants.Md5;

        public string Version { get; set; } = ApiConstants.Version10;

        public string HttpMethod { get; set; }

        public string Path { get; set; }

        public int Timeout { get; set; } = 30;

        public GalileoApiConfig.Category Category { get; set; } = GalileoApiConfig.Category.MerchantApi;
    }

    public class PostApiAttribute : ApiAttribute
    {
        public PostApiAttribute()
        {
            HttpMethod = ApiConstants.Post;
        }
    }

    public class GetApiAttribute : ApiAttribute
    {
        public GetApiAttribute()
        {
            HttpMethod = ApiConstants.Get;
        }
    }
}
