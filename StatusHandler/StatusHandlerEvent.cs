using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tessup
{
    class StatusHandlerEvent
    {
        public delegate Task WriteStatusEvent(string statusName, string statusOutput, string handler);
        public static event WriteStatusEvent StatusEvent;

        public static void OnWriteStatus(string statusName, string statusOutput, string handler)
        {
            if (StatusEvent == null) return;
            StatusEvent(statusName, statusOutput, handler);
        }
    }
}
