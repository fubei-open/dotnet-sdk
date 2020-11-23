using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Configuration;

namespace Com.Illuminati.Galileo.Foundation
{
    public class GalileoConfiguration
    {
        private readonly DictionaryAdapterFactory _factory = new DictionaryAdapterFactory();

        public Hashtable ConfigurationMap { get; set; } = new Hashtable();

        public T GetConfiguration<T>()
        {
            return _factory.GetAdapter<T>(ConfigurationMap);
        }

        public void TryAdd(string key, object value)
        {
            if (value != null && !string.IsNullOrEmpty(key))
            {
                ConfigurationMap[key] = value;
            }
        }
    }
}
