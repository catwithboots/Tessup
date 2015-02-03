using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Tessup
{
    public class LogHandler : ILogHandler
    {
        public string logMethod { get; set; }
        public LogHandler()
        {
            //moet in appdir een config uitlezen en dan zorgen dat ie daar iets mee doet als je een method gebruikt
            logMethod = "nlog";
        }
        public void Info()
        {
            //Logger logger=new Logger();
            //logger.Info("blaat");
        }

        public void Warning()
        {
            throw new NotImplementedException();
        }

        public void Error()
        {
            throw new NotImplementedException();
        }

        public void Verbose()
        {
            throw new NotImplementedException();
        }

        public void Debug()
        {
            throw new NotImplementedException();
        }
    }
}
