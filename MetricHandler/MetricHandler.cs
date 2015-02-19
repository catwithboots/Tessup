﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LibInfluxDB.Net;
using LibInfluxDB.Net.Models;

namespace Tessup
{   
    public class Metric
    {
        public string TargetName { get; set; }
        public string ObjectName { get; set; }
        public string ValueName { get; set; }
        public object Values { get; set; }
        public Metric(string targetName, string objectName, string pointNames, object values)
        {
            TargetName = targetName;
            ObjectName = objectName;
            ValueName = pointNames;
            Values = values;
        }
    }

    class MetricHandlerEvent
    {
        //public delegate void WriteMetricEvent(List<Metric> metricList);
        public delegate Task WriteMetricEvent(List<Metric> metricList);
        //Defining event based on the above delegate
        public static event WriteMetricEvent MetricEvent;

        public static void OnWriteMetric(List<Metric> s)
        {
            if (MetricEvent != null)
            {
                MetricEvent(s);
            }
        }
    }

    public class MetricHandler //: IMetricHandler
    {
        public bool UseLog { get; set; }
        public bool UseInfluxDb { get; set; }
        public bool UseGraphite { get; set; }
        public void metricHandler()
        {
            //foreach known and configured method add a handler
            MetricHandlerEvent.MetricEvent += WriteLog;
        }
        public MetricHandler(bool useLog,bool useInfluxDb,bool useGraphite)
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

        public void WriteMetric(List<Metric> metricList)
        {
            MetricHandlerEvent.OnWriteMetric(metricList);
        }

        //Implementations of different writers
        static async Task WriteLog(List<Metric> metricList)
        {
            //kan efficienter door alles naar dezelfde target te sortere/groeperen
            foreach (var m in metricList)
            {
                Stream fs = new FileStream("c:\\logfiles\\" + m.TargetName+ ".txt", FileMode.Append, FileAccess.Write);
                var sw = new StreamWriter(fs);
                sw.WriteLine("Object Name: {0}, Metric Name: {1}, Metric Value: {2}", m.ObjectName, m.ValueName, m.Values);
                sw.Close();
                fs.Close();
                return;
            }
        }
        //void WriteInfluxDb(List<Metric> metricList)
        static async Task WriteInfluxDb(List<Metric> metricList)
        {
            // convert metriclist to lists(s) that is optimal for influxdb
            //foreach influxdbmetric do sent it to influxdb


            var connect = new InfluxDb("http://influxdb.jollyrogers.nl:8086", "tessup", "tessup");
            foreach (var m in metricList)
            {
                var payload = new Serie.Builder(m.ObjectName).Columns(m.ValueName).Values(m.Values).Build();
                //Task<LibInfluxDB.Net.InfluxDbApiResponse> pushMetric = connect.WriteAsync("tessup", LibInfluxDB.Net.TimeUnit.Milliseconds, payload);
                var pushMetric = await connect.WriteAsync(m.TargetName, TimeUnit.Milliseconds, payload);
                return;
                //Task<InfluxDbApiResponse> pushMetric = connect.WriteAsync(m.TargetName, TimeUnit.Milliseconds, payload);

            }
            

        }

        static async Task WriteGraphite(List<Metric> metricList)
        {
            foreach (var m in metricList)
            {
                Stream fs = new FileStream("c:\\logfiles\\" + m.TargetName + "_graphite.txt", FileMode.Append, FileAccess.Write);
                TextWriter sw = new StreamWriter(fs);
                if (m.Values != null)
                    sw.WriteLine("Object Name: {1}, Metric Name: {2}, Metric Value: {3}", m.ObjectName, m.ValueName, m.Values);
                sw.Close();
                fs.Close();
                return;
            }
        }

    }
}
