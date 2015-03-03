using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LibInfluxDB.Net;
using LibInfluxDB.Net.Models;

namespace Tessup
{
    public class Metrics //: IMetricHandler
    {
       public static readonly LogHandler MyLogger = new LogHandler();
        
        public Metrics(bool useLog, bool useInfluxDb, bool useGraphite)
        {
            UseInfluxDb = useInfluxDb;
            UseGraphite = useGraphite;
            UseLog = useLog;

            //foreach known and configured method add a handler
            if (useLog)
            {
                MetricHandlerEvent.MetricEvent += WriteLog;
            }
            if (useInfluxDb)
            {
                MetricHandlerEvent.MetricEvent += WriteInfluxDb;
            }
            if (useGraphite)
            {
                MetricHandlerEvent.MetricEvent += WriteGraphite;
            }
        }

        public bool UseLog { get; set; }
        public bool UseInfluxDb { get; set; }
        public bool UseGraphite { get; set; }

        public void Handler()
        {
            //foreach known and configured method add a handler
            MetricHandlerEvent.MetricEvent += WriteLog;
        }

        public void WriteMetric(List<Metric> metricList)
        {
            MetricHandlerEvent.OnWriteMetric(metricList);
        }

        //Implementations of different writers
        private static async Task WriteLog(List<Metric> metricList)
        {
            //kan efficienter door alles naar dezelfde target te sortere/groeperen
            foreach (var m in metricList)
            {
                Stream fs = new FileStream("c:\\logfiles\\" + m.TargetName + ".txt", FileMode.Append, FileAccess.Write);
                var sw = new StreamWriter(fs);
                sw.WriteLine("Object Name: {0}, Metric Name: {1}, Metric Value: {2}", m.ObjectName, m.ValueName,
                    m.Values);
                sw.Close();
                fs.Close();
                MetricHandlerEvent.MetricEvent -= WriteLog;
                return;
            }
        }

        private static async Task WriteInfluxDb(List<Metric> metricList)
        {
            // convert metriclist to lists(s) that is optimal for influxdb
            //foreach influxdbmetric do sent it to influxdb


            var connect = new InfluxDb(@"http://influxdb.jollyrogers.nl:8086", "tessup", "tessup");
            foreach (var m in metricList)
            {
                var payload = new Serie.Builder(m.ObjectName).Columns(m.ValueName).Values(m.Values).Build();
                try
                {
                    await connect.WriteAsync(m.TargetName, TimeUnit.Milliseconds, payload);
                }
                catch (Exception ex)
                {

                    MyLogger.Warning(string.Format("Sending metric to influxdb failed: " + ex.InnerException.Message));
                }
                MetricHandlerEvent.MetricEvent -= WriteInfluxDb;
                return;
            }
        }

        private static async Task WriteGraphite(List<Metric> metricList)
        {
            foreach (var m in metricList)
            {
                Stream fs = new FileStream("c:\\logfiles\\" + m.TargetName + "_graphite.txt", FileMode.Append,
                    FileAccess.Write);
                TextWriter sw = new StreamWriter(fs);
                if (m.Values != null)
                    sw.WriteLine("Object Name: {0}, Metric Name: {1}, Metric Value: {2}", m.ObjectName, m.ValueName,
                        m.Values);
                sw.Close();
                fs.Close();
                MetricHandlerEvent.MetricEvent -= WriteGraphite;
                return;
            }
        }
    }
}