using System;
using System.Collections.Generic;
using NLog;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Tessup.Shared;
using System.Diagnostics;

namespace Tessup
{
    public class LogHandler : ILogHandler
    {
        // Public Properties
        public string LogMethod { get; set; }
        public Config Config { get; set; }
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
            Config = GetConfig();
            // Set nlog specifics if enabled
            if (!Config.LogHandler.nlog) return;
            _nLog = LogManager.GetCurrentClassLogger();
            _nLogLevels.Add("Trace", _nLog.GetType().GetMethod("Trace", new[] { typeof(string) }));
            _nLogLevels.Add("Debug", _nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            _nLogLevels.Add("Info", _nLog.GetType().GetMethod("Info", new[] { typeof(string) }));
            _nLogLevels.Add("Warning", _nLog.GetType().GetMethod("Warn", new[] { typeof(string) }));
            _nLogLevels.Add("Error", _nLog.GetType().GetMethod("Error", new[] { typeof(string) }));
            _nLogLevels.Add("Verbose", _nLog.GetType().GetMethod("Debug", new[] { typeof(string) }));
            _nLogLevels.Add("Fatal", _nLog.GetType().GetMethod("Fatal", new[] { typeof(string) }));
            LogHandlerEvent.LogEvent += NLogDo;
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
        public void Debug(string line,StackInfo si)
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
        private Config GetConfig()
        {
            string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Tessup.config");
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            Config ei = (Config)serializer.Deserialize(new StringReader(xml));
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
