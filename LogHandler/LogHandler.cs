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

namespace Tessup
{
    public class LogHandler : ILogHandler
    {
        public string logMethod { get; set; }
        public Config config { get; set; }
        Logger nLog;
        public LogHandler()
        {
            this.config = GetConfig();
            if (this.config.LogHandler.nlog)
            {
                this.nLog = LogManager.GetCurrentClassLogger();
                LogHandlerEvent.logInfoEvent += (l,e) => NLogDo(l,e);
            }
        }
        public void Info(string line)
        {
            string logLevel = System.Reflection.MethodBase.GetCurrentMethod().Name;
            LogHandlerEvent.onLogInfo(logLevel,line);
            
        }

        public void Warning(string line)
        {
            throw new NotImplementedException();
        }

        public void Error(string line)
        {
            throw new NotImplementedException();
        }

        public void Verbose(string line)
        {
            throw new NotImplementedException();
        }

        public void Debug(string line)
        {
            throw new NotImplementedException();
        }


        public void Fatal(string line)
        {
            throw new NotImplementedException();
        }

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
            MethodInfo method = this.nLog.GetType()
            .GetMethod(l,new Type[] { typeof(string)});
            method.Invoke(nLog,new Object[]{ s});
        }
        
    }

    class LogHandlerEvent
    {
        public delegate void LogInfoEvent(string logLevel,string line);
        //Defining event based on the above delegate
        public static event LogInfoEvent logInfoEvent;

        public static void onLogInfo(string l,string s)
        {
            if (logInfoEvent != null)
            {
                logInfoEvent(l,s);
            }
        }
    }
}
