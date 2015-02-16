using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Graphite;
using LibInfluxDB;

namespace Tessup
{   
    public class Metric
    {
        public string targetName { get; set; }
        public string objectName { get; set; }
        public string valueName { get; set; }
        public object value { get; set; }
        public Metric(string targetName, string objectName, string valueName, object value)
        {
            this.objectName = objectName;
            this.targetName = targetName;
            this.valueName = valueName;
            this.value = value;
        }
    }

    class MetricHandlerEvent
    {
        public delegate void WriteMetricEvent(List<Metric> metricList);
        //Defining event based on the above delegate
        public static event WriteMetricEvent writeMetricEvent;

        public static void onWriteMetric(List<Metric> s)
        {
            if (writeMetricEvent != null)
            {
                writeMetricEvent(s);
            }
        }
    }

    public class MetricHandler : IMetricHandler
    {
        public bool useLog { get; set; }
        public bool useInfluxDb { get; set; }
        public bool useGraphite { get; set; }
        public MetricHandler()
        {
            //foreach known and configured method add a handler
            MetricHandlerEvent.writeMetricEvent += (e) => WriteLog(e);
        }
        public MetricHandler(bool useLog,bool useInfluxDb,bool useGraphite)
        {
            this.useInfluxDb = useInfluxDb;
            this.useGraphite = useGraphite;
            this.useLog = useLog;
            
            
            //foreach known and configured method add a handler
            if (useLog)
            {
                MetricHandlerEvent.writeMetricEvent += (e) => WriteLog(e);
            }
            if (useInfluxDb)
            {
                MetricHandlerEvent.writeMetricEvent += (e) => WriteInfluxDb(e);
            }
            if (useGraphite)
            {
                MetricHandlerEvent.writeMetricEvent += (e) => WriteGraphite(e);
            }
        }

        public void WriteMetric(List<Metric> metricList)
        {
            MetricHandlerEvent.onWriteMetric(metricList);
        }

        //Implementations of different writers
        void WriteLog(List<Metric> metricList)
        {
            //kan efficienter door alles naar dezelfde target te sortere/groeperen
            foreach (Metric m in metricList)
            {
                FileStream fs = new FileStream("c:\\logfiles\\" + m.targetName+ ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Object Name: {0}, Metric Name: {1}, Metric Value: {2}", m.objectName, m.valueName, m.value.ToString());
                sw.Close();
                fs.Close();
            }
        }
        //void WriteInfluxDb(List<Metric> metricList)
        void WriteInfluxDb(List<Metric> metricList)
        {
            // convert metriclist to lists(s) that is optimal for influxdb
            //foreach influxdbmetric do sent it to influxdb


            LibInfluxDB.Net.InfluxDb connect = new LibInfluxDB.Net.InfluxDb("http://influxdb-tessup-1.kmeinster.cont.tutum.io:8086", "tessup", "tessup");
            foreach (Metric m in metricList)
            {
                LibInfluxDB.Net.Models.Serie payload = new LibInfluxDB.Net.Models.Serie.Builder(m.objectName).Columns(m.valueName).Values(m.value).Build();
                Task<LibInfluxDB.Net.InfluxDbApiResponse> pushMetric = connect.WriteAsync("tessup", LibInfluxDB.Net.TimeUnit.Milliseconds, payload);
            }
            

        }
        void WriteGraphite(List<Metric> metricList)
        {
            foreach (Metric m in metricList)
            {
                FileStream fs = new FileStream("c:\\logfiles\\" + m.targetName + "_graphite.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Object Name: {1}, Metric Name: {2}, Metric Value: {3}", m.objectName, m.valueName, m.value.ToString());
                sw.Close();
                fs.Close();
            }
        }

    }
}
