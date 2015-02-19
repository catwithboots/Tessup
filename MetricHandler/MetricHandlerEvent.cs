using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tessup
{
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
}