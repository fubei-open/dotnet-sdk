using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Model
{
    /// <summary>
    /// List包装Model
    /// 为了适配开放平台1.0
    /// { data: list: [] }
    /// 的数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListWrappedModel<T> where T : IBaseModel
    {
        public List<T> List { get; set; }
    }
}
