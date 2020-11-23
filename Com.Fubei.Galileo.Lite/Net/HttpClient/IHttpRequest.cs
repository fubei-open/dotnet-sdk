using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Com.Illuminati.Galileo.Attr;

namespace Com.Illuminati.Galileo.Net.HttpClient
{
    /// <summary>
    /// HTTP工具
    /// </summary>
    public interface IHttpRequest<TE>
    {
        /// <summary>
        /// 获得代理服务器地址
        /// </summary>
        IWebProxy WebProxy { get; set; }

        /// <summary>
        /// Post数据
        /// </summary>
        /// <param name="host"></param>
        /// <param name="attr"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        TE PostRequest(string host, ApiAttribute attr, IEnumerable<KeyValuePair<string, object>> paramList);

        /// <summary>
        /// 添加自定义请求头
        /// </summary>
        /// <param name="headerList"></param>
        void AddCustomHeader(IEnumerable<KeyValuePair<string, string>> headerList);
    }

    /// <summary>
    /// 请求返回string类型的Http请求
    /// </summary>
    public interface IHttpRequest : IHttpRequest<string>
    {
    }
}
