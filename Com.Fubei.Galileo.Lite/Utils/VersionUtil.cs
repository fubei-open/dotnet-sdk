using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Foundation;

namespace Com.Illuminati.Galileo.Utils
{
    public class VersionUtil
    {
        public static bool IsOldVersion()
        {
            var os = Environment.OSVersion;
            return os.Version.Major <= 5;
        }
    }
}
