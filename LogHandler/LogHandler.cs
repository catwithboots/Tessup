using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using NLog;

namespace Tessup
{
    public class LogHandler : ILogHandler
    {
        // Public Properties
        public string LogMethod { get; set; }
        public Config.Config Config { get; set; }

        // Private properties
        readonly Logger _nLog;
        readonly Dictionary<string, MethodInfo> _nLogLevels = new Dictionary<string, MethodInfo>();	    

        // Constructor implementation
        public LogHandler()
        {
            Config = GetConfig();
            // Set nlog specifics if enabled
            if (!Config.LogHandler.Nlog) return;
            _nLog = LogManager.GetCurrentClassLogger();
            _nLogLevels.Add("Trace", _nLog.GetType().GetMethod("Trace", new[] { typeof(string) }));
            _nLogLevels.Add("Debug", _nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            _nLogLevels.Add("Info", _nLog.GetType().GetMethod("Info", new[] { typeof(string) }));
            _nLogLevels.Add("Warning", _nLog.GetType().GetMethod("Warn", new[] { typeof(string) }));
            _nLogLevels.Add("Error", _nLog.GetType().GetMethod("Error", new[] { typeof(string) }));
            _nLogLevels.Add("Verbose", _nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            _nLogLevels.Add("Fatal", _nLog.GetType().GetMethod("Fatal", new[] { typeof(string) }));
            LogHandlerEvent.logEvent += (l,e) => NLogDo(l,e);
        }
        // Method Implementation of interface
        public void Trace(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }
        public void Info(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Warning(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Error(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Verbose(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Debug(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Fatal(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        // Internal methods
        private Config.Config GetConfig()
        {
            string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Tessup.config");
            XmlSerializer serializer = new XmlSerializer(typeof(Config.Config));
            Config.Config ei = (Config.Config)serializer.Deserialize(new StringReader(xml));
            return ei;
        }

        //Implementations of different writers
        void NLogDo(string l,string s)
        {
            MethodInfo method;
            if (_nLogLevels.TryGetValue(l, out method))
            {
                method.Invoke(_nLog, new Object[] { s });
            }
        }
    }

    class LogHandlerEvent
    {
        public delegate void LogEvent(string logLevel,string line);
        //Defining event based on the above delegate
        public static event LogEvent logEvent;

        public static void OnLog(string l,string s)
        {
            if (logEvent != null)
            {
                logEvent(l,s);
            }
        }
    }
}
