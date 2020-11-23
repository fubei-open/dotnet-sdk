using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Com.Illuminati.Galileo.Attr;

namespace Com.Illuminati.Galileo.Net
{
    class InvocationInfo
    {
        public ApiAttribute ApiAttribute { get; set; }

        public ParameterInfo[] ParameterInfos { get; set; }
    }
}
