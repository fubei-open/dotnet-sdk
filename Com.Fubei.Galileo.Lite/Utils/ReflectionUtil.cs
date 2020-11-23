using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Com.Illuminati.Galileo.Utils
{
    public class ReflectionUtil
    {
        private static readonly Dictionary<string, MethodInfo> MethodInfos = new Dictionary<string, MethodInfo>();
        
        private static readonly object Sync = new object();

        public static object Invoke(object obj, string methodName, object[] parameters)
        {
            if (obj == null)
            {
                return null;
            }

            var id = GetMethodIdentifier(obj.GetType(), methodName);
            MethodInfo methodInfo = null;
            lock (Sync)
            {
                if (MethodInfos.ContainsKey(id))
                {
                    methodInfo = MethodInfos[id];
                }
                else
                {
                    methodInfo = obj.GetType().GetMethod(methodName);
                    if (methodInfo != null)
                    {
                        MethodInfos.Add(id, methodInfo);
                    }
                }
            }

            return methodInfo?.Invoke(obj, BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder,
                parameters, CultureInfo.CurrentCulture);
        }

        private static string GetMethodIdentifier(Type type, string methodName)
        {
            return $"{type.FullName}.{methodName}";
        }

        internal static void Invoke(object returnValue, string rEJECT, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
