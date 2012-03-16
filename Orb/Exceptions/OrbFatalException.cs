using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbFatalException : OrbBaseException
    {
        public override string Message
        {
            get { return "Fatal Exception"; }
        }


        public string ExtraInfo
        {
            get
            {
                return
                    "Please restart the application.";
            }
        }

        public string ShortName
        {
            get
            {
                return
                    "ERR0000";
            }
        }

    }
}
