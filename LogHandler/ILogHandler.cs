using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tessup
{
    interface ILogHandler
    {
        void Info();
        void Warning();
        void Error();
        void Verbose();
        void Debug();
    }
}
