using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAXNew
{
    public sealed class SystemConfiguration
    {
        public static string AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        protected SystemConfiguration() { }
    }
}
