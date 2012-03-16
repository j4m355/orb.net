using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbNoSessionIdFailure : OrbBaseException
    {
        public override string Message
        {
            get { return "None or invalid session id."; }
        }


        public string ExtraInfo
        {
            get
            {
                return
                    "Try to restart the application. If the problem persist, please contact the author.";
            }
        }

        public string ShortName
        {
            get
            {
                return
                    "ERR0003";
            }
        }

    }
}
