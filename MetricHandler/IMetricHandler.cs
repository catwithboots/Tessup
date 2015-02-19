using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tessup
{
    interface IMetricHandler
    {
        Task WriteMetric(List<Metric> metricList);
    }
}
