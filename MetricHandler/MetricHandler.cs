﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tessup
{   
    public class Metric
    {
        public string Name { get; set; }
        public object Value { get; set; }
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
        public void WriteMetric(List<Metric> metricList)
        {
            MetricHandlerEvent.onWriteMetric(metricList);
        }

        void WriteLog(List<Metric> metricList)
        {
            FileStream fs = new FileStream("c:\\logfiles\\poep.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Metric m in metricList)
            {
                sw.WriteLine("Metric Name: {0}", m.Name);
                sw.WriteLine("Metric Value: {0}", m.Value);
            }
            sw.Close();
            fs.Close();
        }

        public MetricHandler()
        {
            //foreach known and configured method add a handler
            MetricHandlerEvent.writeMetricEvent += (e) => WriteLog(e);
        }

    }
}
