using System;
using System.Collections.Generic;
using NLog;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Config;

namespace Tessup
{
    public class LogHandler : ILogHandler
    {
        // Public Properties
        public string LogMethod { get; set; }
        public Configure Config { get; set; }
        public enum StackInfo
        {
            None,
            CurrentMethod,
            Full
        }

        // Private properties
        readonly Logger _nLog;
        readonly Dictionary<string, MethodInfo> _nLogLevels = new Dictionary<string, MethodInfo>();	    

        // Constructor implementation
        public LogHandler()
        {
            var configuration = GetConfig();
            // Set nlog specifics if enabled
            if (!configuration.LogHandler.Nlog) return;
            nLog = LogManager.GetCurrentClassLogger();
            nLogLevels.Add("Trace", nLog.GetType().GetMethod("Trace", new[] { typeof(string) }));
            nLogLevels.Add("Debug", nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            nLogLevels.Add("Info", nLog.GetType().GetMethod("Info", new[] { typeof(string) }));
            nLogLevels.Add("Warning", nLog.GetType().GetMethod("Warn", new[] { typeof(string) }));
            nLogLevels.Add("Error", nLog.GetType().GetMethod("Error", new[] { typeof(string) }));
            nLogLevels.Add("Verbose", nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            nLogLevels.Add("Fatal", nLog.GetType().GetMethod("Fatal", new[] { typeof(string) }));
            LogHandlerEvent.logEvent += (l, e) => NLogDo(l, e);
        }
        // Method Implementation of interface
        public void Trace(string line)
        {
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }
        public void Info(string line)
        {
            line = new StackFrame(1).GetMethod().Name + " | " + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Warning(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Error(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Verbose(string line)
        {
            line = new StackFrame(1).GetMethod().Name + " | " + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Debug(string line)
        {
            //line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }
        public void Debug(string line, StackInfo si)
        {
            switch (si)
            {
                case StackInfo.CurrentMethod:
                    line = new StackFrame(1).GetMethod().Name + " | " + line;
                    break;
                case StackInfo.Full:
                    //StackTrace st = new StackTrace();
                    //StackFrame[] sfs= st.GetFrames();
                    line = Environment.StackTrace + " | " + line;
                    break;
                case StackInfo.None:
                    break;
            }
                
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        public void Fatal(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.OnLog(MethodBase.GetCurrentMethod().Name, line);
        }

        // Internal methods
        private static Configure GetConfig()
        {
            var xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Tessup.config");
            var serializer = new XmlSerializer(typeof(Configure));
            var ei = (Configure)serializer.Deserialize(new StringReader(xml));
            return ei;
        }

        //Implementations of different writers
        void NLogDo(string l, string s)
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
        public delegate void LogEventDelegate(string logLevel,string line);
        //Defining event based on the above delegate
        public static event LogEventDelegate LogEvent;

        public static void OnLog(string l,string s)
        {
            if (LogEvent != null)
            {
                LogEvent(l,s);
            }
        }
    }
}
