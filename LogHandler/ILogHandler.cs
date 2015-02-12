using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tessup
{
    interface ILogHandler
    {
        void Info(string line);
        void Warning(string line);
        void Error(string line);
        void Verbose(string line);
        void Debug(string line);
        void Fatal(string line);
    }
}
