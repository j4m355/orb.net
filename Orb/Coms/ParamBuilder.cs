using System;
using System.Web;

namespace Orb.Coms
{
    public class ParamBuilder
    {
        public string ParamString;

        public void addParam(string paramName, string paramData)
        {
            ParamString = ParamString + paramName + "=" + HttpUtility.UrlEncode(paramData) + "&";
        }

        public string GetParamList()
        {
            try
            {
                return ParamString.TrimEnd('&');
            }
            catch(Exception ex)
            {
                return "";
               
            }
        }
    }
}
