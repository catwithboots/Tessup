using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tessup
{
    interface IMetricHandler
    {
        void WriteMetric(List<Metric> metricList);
    }
}
