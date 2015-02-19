using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Xml;
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
        readonly Logger nLog;
        Dictionary<string, MethodInfo> nLogLevels = new Dictionary<string, MethodInfo>();

        // Constructor implementation
        public LogHandler()
        {
            this.Config = GetConfig();
            // Set nlog specifics if enabled
            if (!Config.LogHandler.Nlog) return;
            this.nLog = LogManager.GetCurrentClassLogger();
            nLogLevels.Add("Trace", this.nLog.GetType().GetMethod("Trace", new Type[] { typeof(string) }));
            nLogLevels.Add("Debug", this.nLog.GetType().GetMethod("Debug", new Type[] { typeof(string) }));
            nLogLevels.Add("Info", this.nLog.GetType().GetMethod("Info", new Type[] { typeof(string) }));
            nLogLevels.Add("Warning", this.nLog.GetType().GetMethod("Warn", new Type[] { typeof(string) }));
            nLogLevels.Add("Error", this.nLog.GetType().GetMethod("Error", new Type[] { typeof(string) }));
            nLogLevels.Add("Verbose", this.nLog.GetType().GetMethod("Debug", new Type[] { typeof(string) }));
            nLogLevels.Add("Fatal", this.nLog.GetType().GetMethod("Fatal", new Type[] { typeof(string) }));
            LogHandlerEvent.logEvent += (l, e) => NLogDo(l, e);
        }
        // Method Implementation of interface
        public void Trace(string line)
        {
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }
        public void Info(string line)
        {
            line = new StackFrame(1).GetMethod().Name + " | " + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        public void Warning(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        public void Error(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        public void Verbose(string line)
        {
            line = new StackFrame(1).GetMethod().Name + " | " + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        public void Debug(string line)
        {
            //line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }
        public void Debug(string line, StackInfo si)
        {
            switch (si)
            {
                case StackInfo.CurrentMethod:
                    line = new StackFrame(1).GetMethod().Name + " | " + line;
                    break;
                case StackInfo.Full:
                    StackTrace st = new StackTrace();
                    StackFrame[] sfs = st.GetFrames();
                    line = Environment.StackTrace + " | " + line;
                    break;
                case StackInfo.None:
                    break;
            }

            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        public void Fatal(string line)
        {
            line = new StackFrame(1).GetMethod().Name + "\t|\t" + line;
            LogHandlerEvent.onLog(System.Reflection.MethodBase.GetCurrentMethod().Name, line);
        }

        // Internal methods
        private static Configure GetConfig()
        {
            string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Tessup.config");
            XmlSerializer serializer = new XmlSerializer(typeof(Configure));
            Configure ei = (Configure)serializer.Deserialize(new StringReader(xml));
            return ei;
        }

        //Implementations of different writers
        void NLogDo(string l, string s)
        {
            MethodInfo method;
            if (nLogLevels.TryGetValue(l, out method))
            {
                method.Invoke(nLog, new Object[] { s });
            }
        }
    }
}