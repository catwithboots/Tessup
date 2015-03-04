using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Tessup
{
    interface IStatusHandlers
    {
        //Sample message to Sensu Client
        //    {
        //        "handlers": ["default"],
        //        "name": "check-dikke-poep",
        //        "output": "CRITICAL: Poep is niet zo dik!",
        //        "status": 2
        //    }

        void Ok(string name, string output, string handler);
        void Warning(string name, string output, string handler);
        void Critical(string name, string output, string handler);
        void Unknown(string name, string output, string handler);

        //Task WriteStatus(string name, string output);
        //Task WriteStatus(string name, string output, string handler);
    }
}
