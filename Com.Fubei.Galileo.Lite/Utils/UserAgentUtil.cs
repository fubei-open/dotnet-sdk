using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Com.Illuminati.Galileo.Foundation;
using Com.Illuminati.Galileo.Net;

namespace Com.Illuminati.Galileo.Utils
{
    public class UserAgentUtil
    {
        public static UserAgentUtil Instance = new UserAgentUtil();

        private const string ClientVersion = "1.1.0.20200528";

        private static string _uAgent = $"GALILEO.Library {ClientVersion}({Environment.OSVersion})" +
                                               $" .NetFramework/{Environment.Version}";

        public void AddToUserAgent(string key, object value)
        {
            if (key == null || value == null)
            {
                return;
            }
            _uAgent += $" {CodecUtil.UrlEncode(key)}/{CodecUtil.UrlEncode(value.ToString())}";
        }

        public string FinaleValue => _uAgent;
    }
}
