using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbInternalError : OrbBaseException
    {
        public override string Message
        {
            get { return "Internal error."; }
        }


        public string ExtraInfo
        {
            get
            {
                return
                    "An unknown internal error has occured. Please inform the developer and provide steps to reproduce this problem.";
            }
        }

        public string ShortName
        {
            get
            {
                return
                    "ERR0004";
            }
        }

    }
}
