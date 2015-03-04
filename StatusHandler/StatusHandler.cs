using System.IO;
using System.Threading.Tasks;

namespace Tessup
{
    public class StatusHandler : IStatusHandlers
    {
    //Sample message to Sensu Client
    //    {
    //        "handlers": ["default"],
    //        "name": "check-dikke-poep",
    //        "output": "CRITICAL: Poep is niet zo dik!",
    //        "status": 2
    //    }
        public Status(bool UseSensu, bool UseNagios, bool UseText)
        {
            UseSensu = UseSensu;
            UseNagios = UseNagios;
            UseText = UseText;

            //foreach known and configured method add a handler
            if (UseSensu)
            {
                StatusHandlerEvent.StatusEvent += WriteStatusText;
            }
            if (UseNagios)
            {
                StatusHandlerEvent.StatusEvent += WriteStatusText;
            }
            if (UseText)
            {
                StatusHandlerEvent.StatusEvent += WriteStatusText;
            }
        }
        public bool UseSensu { get; set; }
        public bool UseNagios { get; set; }
        public bool UseText { get; set; }
        
        private static async Task WriteStatusText(string name, string output, string handler)
        {
            Stream fs = new FileStream("c:\\logfiles\\statusAlert.txt", FileMode.Append,
            FileAccess.Write);
            TextWriter sw = new StreamWriter(fs);
               sw.WriteLine("Status Name: {0}, Status output: {1}, Status Handler: {2}", name, output, handler);
            sw.Close();
            fs.Close();
        }
    }
}
