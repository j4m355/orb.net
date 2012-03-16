using System;
using System.Timers;

namespace Orb.Core.Session
{
    public class SessionKeepAliveTimer
    {
        private static Timer keepAliveTimer;
        private double _interval { get; set; }
     

        public SessionKeepAliveTimer(string interval)
        {
            _interval= Convert.ToDouble(interval);
            keepAliveTimer = new Timer();
            keepAliveTimer.Interval = IntervalInMiliseconds() ;
            keepAliveTimer.AutoReset = true;
        }

        private double IntervalInMiliseconds()
        {
            var temp = (_interval*60000)-60000;
            return temp;
        }

        public void StartTimer()
        {
            keepAliveTimer.Start();
            keepAliveTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var KeepAlive = new Session();
            KeepAlive.sessionkeepAlive();
          
        }
    }
}
