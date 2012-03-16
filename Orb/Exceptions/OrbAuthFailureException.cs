using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbAuthFailureException : OrbBaseException
    {
        public override string Message
        {
            get
            {
                return "Please check your username or password. /r/n/r/n If you're really sure they are correct, please contact the developer of this app. There might be a problem with the API key."
       ;
            }

        }

        public string ExtraInfo
        {
            get
            {
                return
                "Please ask the developer to get an API key.";
            }
        }

        public string ShortName
        {
            get
            {
                return
                    "ERR0001";
            }
        }
    }
}
