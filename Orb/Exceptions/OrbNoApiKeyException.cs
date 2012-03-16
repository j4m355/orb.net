using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Exceptions
{
    public class OrbNoApiKeyException : OrbBaseException
    {
        public override string Message
        {
            get
            {
                return "No API Key Provided";
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
                    "ERR0002";
            }
        }
    }
}
