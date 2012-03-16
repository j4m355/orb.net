using System.Xml;
using Orb.Coms;
using Orb.Data.Models;
using Orb.Data.Models.Session;
using RestSharp;

namespace Orb.Core.Session
{
    public class Session
    {
       
        public string sessionExpireTime { get; set; }

        public Session(string appKey)
        {
           StaticSessionSettings.applicationKey = appKey;
        }

        public Session()
        {
         
        }

        public bool sessionlogin(string username, string password)
        {
            StaticSessionSettings.username = username;
            StaticSessionSettings.password = password;

            var oComm = new Api();
            var oParamBuilder = new ParamBuilder();
            var blnLoggedIn = false;

            oParamBuilder.addParam("apiKey", StaticSessionSettings.applicationKey);
            oParamBuilder.addParam("l", StaticSessionSettings.username);
            oParamBuilder.addParam("password", StaticSessionSettings.password);

            var result = oComm.getResponseFromOrb<Status>(Api.sessionlogin, oParamBuilder.GetParamList());

            StaticSessionSettings.sessionID = result.orbSessionId;
           // if(result.code == "0") 
                blnLoggedIn = true;
            StaticSessionSettings.sessionExpireTime = result.maxInactiveInterval;
           
            return blnLoggedIn;
        }

        public bool sessionkeepAlive()
        {
            var oParamBuilder = new ParamBuilder();
            
            var oComm = new Api();
            oParamBuilder.addParam("sid", StaticSessionSettings.sessionID);
            var result = oComm.getResponseFromOrb<Status>(Api.sessionkeepAlive, oParamBuilder.GetParamList());

            if (result.code == "0")
                return true;

            return false;
        }




    }
}
