using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbBaseException : Exception
    {
        public string ExtraInfo { get { return "Sorry, but no extra information is available for this error."; } }
        public string ShortName
        {
            get { return "ERR9999"; }
        }
    }
}
