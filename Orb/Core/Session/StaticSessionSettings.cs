using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Core.Session
{
    public static class StaticSessionSettings
    {
        public static string applicationKey { get; set; }
        public static string sessionID { get; set;}
        public static string username { get; set;}
        public static string password { get; set;}
        public static string sessionExpireTime { get; set;}
    }
}
