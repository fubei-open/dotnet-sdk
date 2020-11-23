using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Model;
using Com.Illuminati.Galileo.Utils;
using Newtonsoft.Json;

namespace Com.Illuminati.Galileo.Net
{
    internal class FubeiParamParser
    {
        public static object ConvertToParam(ParamType paramType, object obj)
        {
            if (obj == null)
            {
                return null;
            }

            object param;
            switch (paramType)
            {
                case ParamType.Md5:
                    param = HashingUtil.Md5(obj.ToString(), false);
                    break;

                case ParamType.Object:
                    param = obj.ToString();
                    break;

                case ParamType.Json:
                    param = JsonConvert.SerializeObject(obj, ApiConstants.JsonSerializerSettings);
                    break;

                default:
                {
                    param = obj.GetType().IsPrimitive ? obj : obj.ToString();
                    break;
                }
            }

            return param;
        }

        public static void ParseToHashtable(ParameterInfo info, object arg, ref Hashtable hashtable)
        {
            var name = info.Name;
            var attrs = info.GetCustomAttributes(typeof(ApiParamAttribute), true);
            if (attrs.Length != 0 && attrs[0] != null)
            {
                if (!(attrs[0] is ApiParamAttribute attr)) return;
                if (attr.Ignore) return;
                if (!string.IsNullOrEmpty(attr.Name))
                {
                    name = attr.Name;
                }

                var value = ConvertToParam(attr.Type, arg);
                if (value != null)
                {
                    hashtable[name] = value;
                }
            }
            else
            {
                var properties = arg.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var p in properties)
                {
                    ParseProperty(p, arg, ref hashtable);
                }
            }
        }

        public static void ParseProperty(PropertyInfo info, object arg, ref Hashtable hashtable)
        {
            var name = info.Name;
            var attrs = info.GetCustomAttributes(typeof(ApiParamAttribute), true);
            if (attrs.Length != 0 && attrs[0] != null)
            {
                if (attrs[0] is ApiParamAttribute attr)
                {
                    if (!attr.Ignore)
                    {
                        if (!string.IsNullOrEmpty(attr.Name))
                        {
                            name = attr.Name;
                        }

                        var value = ConvertToParam(attr.Type, info.GetValue(arg, null));
                        if (value != null)
                        {
                            hashtable[name] = value;
                        }
                    }
                }
            }
            else
            {
                var properties = arg.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var p in properties)
                {
                    if (p.PropertyType == typeof(IBaseModel))
                    {
                        ParseProperty(p, arg, ref hashtable);
                    }
                    else
                    {
                        hashtable[info.Name] = arg;
                    }
                }
            }
        }

        public static ApiAttribute GetApiAttribute(MemberInfo refMemberInfo)
        {
            return refMemberInfo.GetAttribute<ApiAttribute>();
        }

    }
}
