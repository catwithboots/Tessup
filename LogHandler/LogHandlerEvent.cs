namespace Tessup
{
    class LogHandlerEvent
    {
        public delegate void LogEvent(string logLevel, string line);
        //Defining event based on the above delegate
        public static event LogEvent logEvent;

        public static void onLog(string l, string s)
        {
            if (logEvent != null)
            {
                logEvent(l, s);
            }
        }
    }
}