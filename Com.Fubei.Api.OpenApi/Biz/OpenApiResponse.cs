using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json.Linq;

namespace Com.Illuminati.Galileo.Biz
{
    /// <summary>
    /// 通用返回结果
    /// </summary>
    /// <typeparam name="T">BaseEntity 子类</typeparam>
    public class OpenApiResponse<T> : BaseEntity
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        [JsonProperty("result_code")]
        public int? ResultCode { get; set; }

        /// <summary>
        /// 返回平台错误代码
        /// </summary>
        [JsonProperty("sub_code")]
        public string SubCode { get; set; }

        /// <summary>
        /// 返回结果消息
        /// </summary>
        [JsonProperty("result_message")] 
        public string ResultMessage { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("data")] 
        public T Data { get; set; }
    }

    public class OpenApiResponse : OpenApiResponse<JToken>
    {

    }
}
