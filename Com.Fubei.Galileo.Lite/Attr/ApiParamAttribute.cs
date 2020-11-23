using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Constants;

namespace Com.Illuminati.Galileo.Attr
{
    public enum ParamType
    {
        Default,
        Md5,
        Object,
        Json
    }
    
    public class ApiParamAttribute : Attribute
    {
        public ApiParamAttribute(string name = "")
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public ParamType Type { get; set; } = ParamType.Default;

        public bool Ignore { get; set; } = false;
    }

    public class ApiMd5ParamAttribute : ApiParamAttribute
    {
        public ApiMd5ParamAttribute(string name) : base(name)
        {
            this.Type = ParamType.Md5;
        }
    }

    public class AccessTokenApiParamAttribute : ApiParamAttribute
    {
        public AccessTokenApiParamAttribute() : base(ApiConstants.AccessToken)
        {
        }
    }

    public class ApiObjectParamAttribute : ApiParamAttribute
    {
        public ApiObjectParamAttribute()
        {
            this.Name = "dx";
            this.Type = ParamType.Object;
        }
    }

    public class JsonObjectParamAttribute : ApiParamAttribute
    {
        public JsonObjectParamAttribute()
        {
            this.Name = ApiConstants.JsonTag;
            this.Type = ParamType.Json;
        }
    }
}
