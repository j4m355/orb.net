using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Orb.Coms;
using Orb.Core.Session;
using Orb.Data.Models.Computer;

namespace Orb.Core.Computer
{
    public class Computer
    {
        public PcStatus computergetStatus(string elementName)
        {
            
            if (StaticSessionSettings.sessionID == "")
            {
                throw new Exception("No sessionID specified.");
            }


            var oComm = new Api();
            var result = oComm.getResponseFromOrb<PcStatus>(Api.computergetStatus, "sid=" + StaticSessionSettings.sessionID);
           
            
            return result;
        }

        public bool restartOrb()
        {
            var oParamBuilder = new ParamBuilder();
           
            var oComm = new Api();
            oParamBuilder.addParam("sid", StaticSessionSettings.sessionID);

            var result = oComm.getResponseFromOrb<Status>(Api.computerrestartOrb, oParamBuilder.GetParamList());

            if (result.code == "0")
                return true;

            
            return false;
        }
    }
}
