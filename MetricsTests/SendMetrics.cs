using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tessup;

namespace MetricsTests
{
    [TestClass]
    public class SendMetrics
    {
        [TestMethod]
        public void SendToInfluxDb()
        {
            object poep = 50.8;
            DateTime testTime = DateTime.Now;
            List<Metric> metricList = new List<Metric>();
            metricList.Add(new Metric("tessup", "UnitTest", "WriteToInfluxDB", testTime));
            MetricHandler myMetric = new MetricHandler(true,true,false);
            myMetric.WriteMetric(metricList);
        }
    }
}

