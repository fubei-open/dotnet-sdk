using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Model
{
    /// <summary>
    /// 请求携带数据
    /// </summary>
    [Serializable]
    public class RequestCarrier
    {
        public string Host { get; set; }

        public string RequestMethod { get; set; }
    }
}
