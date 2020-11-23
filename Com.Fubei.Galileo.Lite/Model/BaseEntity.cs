using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Com.Illuminati.Galileo.Model
{
    public interface IBaseModel
    {
        string ToJson();
    }

    [Serializable]
    public class BaseEntity : IBaseModel
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class ResponseEntity : BaseEntity
    {

    }
}
