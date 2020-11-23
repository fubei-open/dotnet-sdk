using Castle.Components.DictionaryAdapter;
using Com.Illuminati.Galileo.Foundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fubei.Api.OpenApi
{
    public interface IOpenApiStorage
    {
        [Key("openapi_host")]
        string OpenApiHost { get; set; }
    }

    public class OpenApiStorage
    {
        private static readonly GalileoConfiguration GalileoConfiguration = new GalileoConfiguration();

        public static IOpenApiStorage Instance => GalileoConfiguration.GetConfiguration<IOpenApiStorage>();

        public static T GetConfiguration<T>()
        {
            return GalileoConfiguration.GetConfiguration<T>();
        }
    }
}
